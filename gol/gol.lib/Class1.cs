using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

	public enum CellState { NotSet, Alive, Dead }

	public class Board
	{
		public Cell[,] Cells { get; set; }

		public int Width { get { return Cells.GetLength(0); } }
		public int Height { get { return Cells.GetLength(1); } }

		public Board(int width, int height)
		{
			Cells = new Cell[width, height];
		}
	}

	public class Game
	{
		private double _seedProbability;

		public Board Board { get; private set; }
		public int Width { get { return Board.Width; } }
		public int Height { get { return Board.Height; } }

		public Game(Board board)
		{
			Board = board;
		}

		public Game(int width, int height, double seedProbability)
		{
			_seedProbability = seedProbability;

			Board = new Board(width, height);

			InitializeBoard();
			Fill();
		}

		private void InitializeBoard()
		{
			for (var i = 0; i < Width; i++)
				for (var j = 0; j < Height; j++)
					Board.Cells[i, j] = new Cell();
		}

		private void Fill()
		{
			var r = new Random();

			foreach (var cell in Board.Cells)
			{
				cell.State = (r.NextDouble() < _seedProbability)
					? CellState.Alive
					: CellState.Dead;
			}
		}
	}

	public class Cell
	{
		public CellState State { get; set; }
	}
}
