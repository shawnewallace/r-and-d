using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace gol.lib
{
	/*
	 * The universe of the Game of Life is an infinite two-dimensional orthogonal
	 * grid of square cells, each of which is in one of two possible states, 
	 * alive or dead. Every cell interacts with its eight neighbours, which are 
	 * the cells that are horizontally, vertically, or diagonally adjacent. At 
	 * each step in time, the following transitions occur:
	 *	
	 *	- Any live cell with fewer than two live neighbours dies, as if caused by 
	 *		under-population.
	 *	- Any live cell with two or three live neighbours lives on to the next 
	 *		generation.
	 *	- Any live cell with more than three live neighbours dies, as if by 
	 *		overcrowding.
	 *	- Any dead cell with exactly three live neighbours becomes a live cell, as 
	 *		if by reproduction.
	 *	
	 * The initial pattern constitutes the seed of the system. The first 
	 * generation is created by applying the above rules simultaneously to every 
	 * cell in the seed—births and deaths occur simultaneously, and the discrete 
	 * moment at which this happens is sometimes called a tick (in other words, 
	 * each generation is a pure function of the preceding one). The rules 
	 * continue to be applied repeatedly to create further generations.
	*/
	public enum Direction
	{
		northwest,
		north,
		northeast,
		east,
		southeast,
		south,
		southwest,
		west
	}

	public class World : List<GolCell>
	{
		public World(int width, int height)
		{

		}

		public GolCell GetCell(int x, int y)
		{
			return this.FirstOrDefault(c => c.X == x && c.Y == y);
		}

		public void Add(GolCell cellToAdd)
		{
			if (Exists(c => c.X == cellToAdd.X && c.Y == cellToAdd.Y)) return;

			base.Add(cellToAdd);
		}

		public void Tick()
		{
			var cellsToDelete = new List<GolCell>();
			foreach (var golCell in this)
			{
				if(golCell.Neighbors.Count() < 2) cellsToDelete.Add(golCell);
				if(golCell.Neighbors.Count() > 3) cellsToDelete.Add(golCell);
			}
			foreach (var golCell in cellsToDelete)
			{
				Remove(golCell);
			}
		}
	}

	public class GolCell
	{
		private World _world;
		public int X { get; private set; }
		public int Y { get; private set; }
		public List<GolCell> Neighbors { get { return GetNeighbors(); } }

		public GolCell(World world, int x = 0, int y = 0)
		{
			_world = world;
			X = x;
			Y = y;
			_world.Add(this);
		}

		public void SpawnAt(int x, int y)
		{
			new GolCell(_world, x, y);
		}

		public void SpawnAt(Direction direction)
		{
			switch(direction)
			{
				case Direction.northwest:
					SpawnAt(X - 1, Y - 1);
					break;
				case Direction.north:
					SpawnAt(X, Y - 1);
					break;
				case Direction.northeast:
					SpawnAt(X + 1, Y - 1);
					break;
				case Direction.east:
					SpawnAt(X + 1, Y);
					break;
				case Direction.southeast:
					SpawnAt(X + 1, Y + 1);
					break;
				case Direction.south:
					SpawnAt(X, Y + 1);
					break;
				case Direction.southwest:
					SpawnAt(X - 1, Y + 1);
					break;
				case Direction.west:
					SpawnAt(X - 1, Y);
					break;
			}
		}

		private List<GolCell> GetNeighbors()
		{
			var result = new List<GolCell>();

			foreach (var golCell in _world)
			{
				if (golCell.X == X       && golCell.Y == (Y - 1)) result.Add(golCell); //northern
				if (golCell.X == (X + 1) && golCell.Y == (Y - 1)) result.Add(golCell); //northeastern
				if (golCell.X == (X + 1) && golCell.Y == Y)       result.Add(golCell); //eastern
				if (golCell.X == (X + 1) && golCell.Y == (Y + 1)) result.Add(golCell); //southeastern
				if (golCell.X == X       && golCell.Y == (Y + 1)) result.Add(golCell); //southern
				if (golCell.X == (X - 1) && golCell.Y == (Y + 1)) result.Add(golCell); //southwestern
				if (golCell.X == (X - 1) && golCell.Y == Y)       result.Add(golCell); //western
				if (golCell.X == (X - 1) && golCell.Y == (Y - 1)) result.Add(golCell); //northwestern
			}
			return result;
		}
	}

	[TestFixture]
	public class spawning_new_cells
	{
		private World _world;

		[SetUp]
		public void SetUp()
		{
			_world = new World();
		}

		[Test]
		public void only_one_cell_per_spot()
		{
			new GolCell(_world, 1, 5);
			new GolCell(_world, 4, 5);
			new GolCell(_world, 4, 5);

			Assert.AreEqual(2, _world.Count());
		}
	}

	[TestFixture]
	public class it_detects_its_neighbors
	{
		private World _world;
		private GolCell _subject;

		[SetUp]
		public void SetUp()
		{
			_world = new World();
			_subject = new GolCell(_world, 3, 5);
		}

		[Test]
		public void coordinates_should_be_correct()
		{
			Assert.AreEqual(3, _subject.X);
			Assert.AreEqual(5, _subject.Y);
		}

		[Test]
		public void world_contains_cell()
		{
			Assert.AreEqual(1, _world.Count());
			Assert.True(_world.Contains(_subject));
		}

		[Test]
		public void it_detects_a_northern_neighbor()
		{
			_subject.SpawnAt(3, 4);
			Assert.AreEqual(1, _subject.Neighbors.Count());
		}

		[Test]
		public void it_detects_a_northeastern_neighbor()
		{
			_subject.SpawnAt(4, 4);
			Assert.AreEqual(1, _subject.Neighbors.Count());
		}

		[Test]
		public void it_detects_a_eastern_neighbor()
		{
			_subject.SpawnAt(4, 5);
			Assert.AreEqual(1, _subject.Neighbors.Count());
		}

		[Test]
		public void it_detects_a_south_eastern_neighbor()
		{
			_subject.SpawnAt(4, 6);
			Assert.AreEqual(1, _subject.Neighbors.Count());
		}

		[Test]
		public void it_detects_a_southern_neighbor()
		{
			_subject.SpawnAt(3, 6);
			Assert.AreEqual(1, _subject.Neighbors.Count());
		}

		[Test]
		public void it_detects_a_southwestern_neighbor()
		{
			_subject.SpawnAt(2, 5);
			Assert.AreEqual(1, _subject.Neighbors.Count());
		}

		[Test]
		public void it_detects_a_western_neighbor()
		{
			_subject.SpawnAt(2, 4);
			Assert.AreEqual(1, _subject.Neighbors.Count());
		}

		[Test]
		public void it_detects_a_northwestern_neighbor()
		{
			_subject.SpawnAt(2, 4);
			Assert.AreEqual(1, _subject.Neighbors.Count());
		}
	}
	
	[TestFixture]
	public class rule_1_any_live_cell_with_fewer_than_two_live_neighbours_dies
	{
		private World _world;
		private GolCell _subject;

		[SetUp]
		public void SetUp()
		{
			_world = new World();
			_subject = new GolCell(_world, 3, 5);
		}

		[Test]
		public void zero_neighbors()
		{
			_world.Tick();
			Assert.True(!_world.Contains(_subject));
		}

		[Test]
		public void one_neighbor()
		{
			_subject.SpawnAt(3, 6);
			_world.Tick();
			Assert.True(!_world.Contains(_subject));
		}
	}

	[TestFixture]
	public class rule_2_any_live_cell_with_two_or_three_live_neighbours_lives_on_to_the_next_generation
	{
		private World _world;
		private GolCell _subject;

		[SetUp]
		public void SetUp()
		{
			_world = new World();
			_subject = new GolCell(_world, 3, 5);
		}

		[Test]
		public void two_neighbors()
		{
			_subject.SpawnAt(_subject.X - 1, _subject.Y);
			_subject.SpawnAt(_subject.X + 1, _subject.Y);

			_world.Tick();
			Assert.True(_world.Contains(_subject));
		}

		[Test]
		public void three_neighbors()
		{
			_subject.SpawnAt(_subject.X - 1, _subject.Y);
			_subject.SpawnAt(_subject.X + 1, _subject.Y);
			_subject.SpawnAt(_subject.X, _subject.Y);

			_world.Tick();
			Assert.True(_world.Contains(_subject));
		}

		[Test]
		public void three_neighbors_four_cells()
		{
			_subject.SpawnAt(_subject.X - 1, _subject.Y);
			_subject.SpawnAt(_subject.X + 1, _subject.Y);
			_subject.SpawnAt(_subject.X, _subject.Y);
			_subject.SpawnAt(0, 0);

			_world.Tick();
			Assert.True(_world.Contains(_subject));
		}
	}

	[TestFixture]
	public class rule_3_any_live_cell_with_more_than_three_live_neighbours_dies
	{
		private World _world;
		private GolCell _subject;

		[SetUp]
		public void SetUp()
		{
			_world = new World();
			_subject = new GolCell(_world, 3, 5);
		}

		[Test]
		public void four_neighbors()
		{
			_subject.SpawnAt(Direction.northeast);
			_subject.SpawnAt(Direction.north);
			_subject.SpawnAt(Direction.east);
			_subject.SpawnAt(Direction.south);
			Assert.AreEqual(4, _subject.Neighbors.Count());

			_world.Tick();
			Assert.True(!_world.Contains(_subject));
		}

		[Test]
		public void five_neighbors_four_cells()
		{
			_subject.SpawnAt(Direction.northeast);
			_subject.SpawnAt(Direction.north);
			_subject.SpawnAt(Direction.east);
			_subject.SpawnAt(Direction.south);
			_subject.SpawnAt(Direction.west);
			Assert.AreEqual(5, _subject.Neighbors.Count());

			_world.Tick();
			Assert.True(!_world.Contains(_subject));
		}
	}

	[TestFixture]
	public class rule_4_any_dead_cell_with_exactly_three_live_neighbours_becomes_a_live_cell
	{
		private World _world;
		private GolCell _subject;

		[SetUp]
		public void SetUp()
		{
			_world = new World();
			_subject = new GolCell(_world, 3, 5);
		}

		[Test]
		public void four_neighbors()
		{
			_subject.SpawnAt(Direction.north);
			_subject.SpawnAt(Direction.south);
			_subject.SpawnAt(Direction.west);
			Assert.AreEqual(3, _subject.Neighbors.Count());

			_world.Tick();
			Assert.True(!_world.Contains(_subject));
		}
	}
}
