using System;
using NUnit.Framework;

namespace gol.lib
{
	public class Board2
	{
		private CellState[,] _cells;

		public int Width { get { return _cells.GetLength(0); } }
		public int Height { get { return _cells.GetLength(1); } }

		public Board2(CellState[,] cells)
		{
			_cells = cells;
		}

		public Board2(int width, int height)
		{
			_cells = new CellState[width, height];

			InitializeBoard();
		}

		private void InitializeBoard()
		{
			for (var i = 0; i < Width; i++)
				for (var j = 0; j < Height; j++)
					_cells[i, j] = CellState.NotSet;
		}

		public CellState NorthwesternNeighbor(int x, int y) { throw new NotImplementedException(); }
		public CellState NorthernNeighbor(int x, int y)     { throw new NotImplementedException(); }
		public CellState NortheasternNeighbor(int x, int y) { throw new NotImplementedException(); }
		public CellState EasternNeighbor(int x, int y)      { throw new NotImplementedException(); }
		public CellState SoutheasternNeighbor(int x, int y) { throw new NotImplementedException(); }
		public CellState SouthernNeighbor(int x, int y)     { throw new NotImplementedException(); }
		public CellState SouthwesternNeighbor(int x, int y) { throw new NotImplementedException(); }
		public CellState WesternNeighbor(int x, int y)      { throw new NotImplementedException(); }

		public CellState Set(int x, int y, CellState newState)
		{
			_cells[x, y] = newState;
			return Get(x, y);
		}
		public CellState Get(int x, int y)
		{
			return _cells[x, y];
		}
	}

	[TestFixture]
	public class Board2Tests_SetTests
	{
		private Board2 _board;

		[SetUp]
		public void SetUp() { _board = new Board2(4, 5); }

		[Test]
		public void it_sets_the_state()
		{
			var cell = _board.Set(2, 3, CellState.Dead);

			Assert.That(_board.Get(2, 3) == CellState.Dead);

			_board.Set(2, 3, CellState.Alive);
			Assert.That(_board.Get(2, 3) == CellState.Alive);
		}
	}
}