using ConwayGameOfLife.Domain;
using NUnit.Framework;

namespace ConwayGameOfLife.Tests.GameTests
{
	[TestFixture]
	public class StartGameTests
	{
		private const int GAME_WIDTH = 10;
		private const int GAME_HEIGHT = 10;
		private const double SEED_PROBABILITY = .1d;

		private Game _game;

		[TestFixtureSetUp]
		public void SetUp()
		{
			_game = new Game(GAME_WIDTH, GAME_HEIGHT, SEED_PROBABILITY);
		}

		[Test]
		public void a_game_has_a_board()
		{
			Assert.IsNotNull(_game.Board);
		}

		[Test]
		public void a_board_has_cells()
		{
			Assert.IsInstanceOf(typeof(Cell[,]), _game.Board);
		}

		[Test]
		public void a_board_has_the_correct_number_of_rows()
		{
			Assert.AreEqual(GAME_WIDTH, _game.Board.GetLength(0));
		}

		[Test]
		public void a_board_has_the_correct_number_of_columns()
		{
			Assert.AreEqual(GAME_HEIGHT, _game.Board.GetLength(1));
		}

		[Test]
		public void all_cells_are_set()
		{
			foreach (var cell in _game.Board)
			{
				Assert.IsNotNull(cell.State);
			}
		}

		[Test]
		public void all_cells_are_dead_or_alive()
		{
			foreach (var cell in _game.Board)
			{
				Assert.That(
					cell.State == CellState.Dead
					|| cell.State == CellState.Alive
				);
			}
		}
	}
}