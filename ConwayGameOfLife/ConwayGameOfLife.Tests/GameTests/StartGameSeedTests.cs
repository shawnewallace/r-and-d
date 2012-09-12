using ConwayGameOfLife.Domain;
using NUnit.Framework;

namespace ConwayGameOfLife.Tests.GameTests
{
	[TestFixture]
	public class StartGameSeedTests
	{
		[Test]
		public void all_cells_are_alive()
		{
			var game = new Game(35, 36, 1d);
			foreach (var cell in game.Board)
			{
				Assert.That(cell.State == CellState.Alive);
			}
		}

		[Test]
		public void all_cells_are_dead()
		{
			var game = new Game(35, 36, 0d);
			foreach (var cell in game.Board)
			{
				Assert.That(cell.State == CellState.Dead);
			}
		}
	}
}