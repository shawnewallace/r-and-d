using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gol.lib;

namespace gol.console
{
	class Program
	{
		static void Main(string[] args)
		{
			var game = new Game(10, 10, .5);

			for(var i = 0; i < game.Width; i++)
			{
				for (var j = 0; j < game.Height; j++ )
				{
					if (game.Board.Cells[i, j].State == CellState.Alive) Console.Write("1_");
					else Console.Write("0_");
				}
				Console.WriteLine("");
			}

			Console.ReadLine();

		}
	}
}
