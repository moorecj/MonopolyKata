using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Board;
using MonopolyKata.Player;
using MonopolyKata.Board.Spaces;

namespace MonopolyKataTests
{
    [TestFixture]
    public class BoardTests
    {

        IPlayer player;
        MonopolyGameBoard gameBoard;

        [SetUp]
        public void SetUp()
        {
            player = new MonopolyPlayer("player");
            gameBoard = new MonopolyGameBoard();
        }

        [Test]
        public void AGameBoardShouldBeAbleToMoveAPlayer()
        {
            player.Location = 0;

            gameBoard.Move(player, 5);

            Assert.That(player.Location, Is.EqualTo(5));
        }

        [Test]
        public void AGameBoardShouldHaveANonZeroAmountOfSpaces()
        {
            Assert.That(gameBoard.GetNumberOfBoardSpaces(), Is.GreaterThan(0));
        }
        
        [Test]
        public void AGameBoardShouldBeAbleToDetermineIfAPlayerHasPassedGo()
        {
            player.Location = 0;

            gameBoard.Move(player,gameBoard.GetNumberOfBoardSpaces()+1);

            Assert.That(gameBoard.DidPlayerPassGo(player), Is.True);
        }

        [Test]
        public void AGameBoardShouldBeAbleToDetermineTheAddressOfASpace()
        {
            Assert.That(gameBoard.GetSpaceAddress(gameBoard.Go), Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void AGameBoardShouldBeAbleToDetermineTheForwardDistaceToASpace()
        {
            int jailLocation = gameBoard.Jail.GetMyLocation();

            Assert.That(gameBoard.GetForwardDistanceToSpace(0, gameBoard.Jail), Is.EqualTo(jailLocation));
        }

        [Test]
        public void AGameBoardShouldBeAbleToDetermineTheForwardDistaceToASpaceThatIsInFrontOfAGivenLocation()
        {
            int jailLocation = gameBoard.Jail.GetMyLocation();

            Assert.That(gameBoard.GetForwardDistanceToSpace(0, gameBoard.Jail), Is.EqualTo(jailLocation));
        }

        [Test]
        public void AGameBoardShouldBeAbleToDetermineTheForwardDistaceToASpaceThatIsBehindAGivenLocation()
        {
            
            int oneMoreThanGo = gameBoard.Go.GetMyLocation() + 1;

            Assert.That(gameBoard.GetForwardDistanceToSpace(oneMoreThanGo, gameBoard.Go), Is.EqualTo(gameBoard.GetNumberOfBoardSpaces() - 1));
        }

    }
}
