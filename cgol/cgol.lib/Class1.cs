using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace cgol.lib
{
	public class World
	{
		private bool[,] _world;

		public World(int x, int y)
		{
			_world = new bool[x, y];

			for (var i = 0; i < x; i++)
				for (var j = 0; j < y; j++)
					_world[i, j] = false;
		}

		public void Tick()
		{
			var x = _world.GetLength(0);
			var y = _world.GetLength(1);

			var newWorld = new bool[x,y];

			for (var i = 0; i < x; i++)
				for (var j = 0; j < y; j++)
					newWorld[i, j] = NextStateIsAlive(i, j);

			_world = newWorld;
		}

		public bool NextStateIsAlive(int x, int y)
		{
			var isAlive = IsAlive(x, y);
			var neighbors = GetNumberOfNeighbors(x, y);

			//Any live cell with fewer than two live neighbours dies, as if caused by under-population.
			if (isAlive && neighbors < 2) return false;

			//Any live cell with two or three live neighbours lives on to the next generation.
			if (isAlive && (neighbors == 2 || neighbors == 3)) return true;
			
			//Any live cell with more than three live neighbours dies, as if by overcrowding.
			if (isAlive && neighbors > 3) return false;
			
			//Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
			if (!isAlive && neighbors == 3) return true;

			return false;
		}

		public int GetNumberOfNeighbors(int x, int y)
		{
			var numLivingNeighbors = 0;

			for (var i = -1; i <= 1; i++)
			{
				if (ColumnNotInBoard(x + i)) continue;

				for (var j = -1; j <= 1; j++)
				{
					if (RowNotInBoard(y + j)) continue;
					if (j == 0 && i == 0) continue; //don't count yourself
					if (_world[x + i, y + j]) numLivingNeighbors++;
				}
			}

			return numLivingNeighbors;
		}
		
		public bool IsAlive(int x, int y)
		{
			return _world[x, y];
		}

		public void SetAlive(int x, int y)
		{
			_world[x, y] = true;
		}

		private bool RowNotInBoard(int y)
		{
			if (y < _world.GetLowerBound(1)) return true;
			if (y > _world.GetUpperBound(1)) return true;
			return false;
		}

		private bool ColumnNotInBoard(int x)
		{
			if (x < _world.GetLowerBound(0)) return true;
			if (x > _world.GetUpperBound(0)) return true;
			return false;
		}
	}

	[TestFixture]
	public class find_number_of_living_neighbors_when_cell_is_on_edge
	{
		private const int NUM_COLS = 3;
		private const int NUM_ROWS = 3;
		private World _world;

		[SetUp]
		public void SetUp()
		{
			_world = new World(NUM_COLS, NUM_ROWS);

			for (var i = 0; i < NUM_COLS; i++)
				for (var j = 0; j < NUM_ROWS; j++)
					_world.SetAlive(i, j);
		}

		[Test]
		public void three_neighbors_in_upper_left_corner()
		{
			Assert.AreEqual(3, _world.GetNumberOfNeighbors(0, 0));
		}

		[Test]
		public void three_neighbors_lower_right_corner()
		{
			Assert.AreEqual(3, _world.GetNumberOfNeighbors(2, 2));
		}

		[TestCase(1, 0)]
		[TestCase(2, 1)]
		[TestCase(1, 2)]
		[TestCase(0, 1)]
		public void five_neighbors_middle_of_edge_corner(int x, int y)
		{
			Assert.AreEqual(5, _world.GetNumberOfNeighbors(x, y));
		}
	}


	[TestFixture]
	public class find_number_of_living_neighbors
	{
		private const int NUM_COLS = 3;
		private const int NUM_ROWS = 3;
		private World _world;

		[SetUp]
		public void SetUp()
		{
			_world = new World(NUM_COLS, NUM_ROWS);
			_world.SetAlive(1, 1);
		}

		[Test]
		public void Zero_Neighbors()
		{
			Assert.AreEqual(0, _world.GetNumberOfNeighbors(1, 1));
		}

		[Test]
		public void One_Neighbor()
		{
			_world.SetAlive(0, 0);
			Assert.AreEqual(1, _world.GetNumberOfNeighbors(1, 1));
		}

		[Test]
		public void Two_Neighbors()
		{
			_world.SetAlive(0, 0);
			_world.SetAlive(2, 2);
			Assert.AreEqual(2, _world.GetNumberOfNeighbors(1, 1));
		}

		[Test]
		public void Eight_Neighbors()
		{
			for (var i = 0; i < NUM_COLS; i++)
				for (var j = 0; j < NUM_ROWS; j++)
					_world.SetAlive(i, j);
			
			Assert.AreEqual(8, _world.GetNumberOfNeighbors(1, 1));
		}
	}
}
