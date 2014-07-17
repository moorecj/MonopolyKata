using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Board;

namespace MonopolyKataTests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void APlayerMove_ShouldIncreaseTheirLocationByTheNumberOfSpacesMoved()
        {
            GameBoard board = new GameBoard();
            MonopolyPlayer player = new MonopolyPlayer("Horse");

            Assert.That(player.Location, Is.EqualTo(0));

            board.Move(player, 6);

            Assert.That(player.Location, Is.EqualTo(6));

        }

        [Test]
        public void APlayerThatMovesBeyondTheLastSpaceOnTheBoard_ShouldLoopAroundToTheBeginingOfBoard()
        {
            GameBoard board = new GameBoard();
            MonopolyPlayer player = new MonopolyPlayer("Horse");

            player.Location = 39;
            
            board.Move(player,6);

            Assert.That(player.Location, Is.EqualTo(5));

        }

        [Test]
        public void APlayerThatGoesOnePositionPastSpace39WillEndUpAtPosition0()
        {
            GameBoard board = new GameBoard();
            MonopolyPlayer player = new MonopolyPlayer("Horse");

            player.Location = 39;
            board.Move(player,1);

            Assert.That(player.Location, Is.EqualTo(0));

        }

        [Test]
        public void APlayerShouldHaveAStartingBalenceOfZero()
        {

            MonopolyPlayer player = new MonopolyPlayer("Horse");
            Assert.That(player.Balence, Is.EqualTo(0));
        }

      
    }
}
