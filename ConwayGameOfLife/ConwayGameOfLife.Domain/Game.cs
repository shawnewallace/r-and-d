using System;
using System.Collections.Generic;

namespace ConwayGameOfLife.Domain
{
	public class Game
	{
		public List<Tuple<int, int, Cell>> Board { get; set; }

		public Game(int width, int height, double seedProbablity)
		{
			InitializeBoard(width, height);
			Seed(seedProbablity);
		}

		private void Seed(double seedProbablity)
		{
			var r = new Random();

			foreach (var cell in Board)
			{
				cell.Item3.State = (r.NextDouble() < seedProbablity)
					? CellState.Alive
					: CellState.Dead;
			}
		}

		private void InitializeBoard(int width, int height)
		{
			Board = new List<Tuple<int, int, Cell>>();

			for (var i = 0; i < width; i++)
				for (var j = 0; j < height; j++)
					Board.Add( new Tuple<int, int, Cell>(i, j, new Cell()));
		}
	}
}