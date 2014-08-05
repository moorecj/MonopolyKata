using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Player;
using MonopolyKata.Board;
using MonopolyKata.Dice;

namespace MonopolyKataTests
{
    [TestFixture]
    public class TurnEngineTests
    {
        MonopolyPlayer player;
        TurnEngine turnEngine;
        MonopolyGameBoard gameBoard;
        public Mock<IDice> diceMock;

        [SetUp]
        public void TurnEngineSetUp()
        {
            diceMock = new Mock<IDice>();
            player = new MonopolyPlayer("Player1");
            gameBoard = new MonopolyGameBoard();
        }

        [Test]
        public void IfAPlayerRollsDoublesThenTheyGetToRollAgain()
        {
            int count = 0;

            diceMock.Setup(m => m.Roll()).Callback(() => { count++; });
            diceMock.Setup(m =>m.GetDiceRollTotal()).Returns(1);
            diceMock.Setup(m => m.LastRollWereAllTheSame()).Returns(true);
            turnEngine = new TurnEngine(diceMock.Object, gameBoard);

            turnEngine.TakeTurn(player);

            Assert.That(count, Is.GreaterThan(1));

        }

        [Test]
        public void IfAPlayerDoesNotRollDoublesThenTheyDoNotRollAgain()
        {
            int count = 0;

            diceMock.Setup(m => m.Roll()).Callback(() => { count++; });
            diceMock.Setup(m => m.GetDiceRollTotal()).Returns(1);
            diceMock.Setup(m => m.LastRollWereAllTheSame()).Returns(false);

            turnEngine = new TurnEngine(diceMock.Object, gameBoard);

            turnEngine.TakeTurn(player);

            Assert.That(count, Is.EqualTo(1));

        }


        [Test]
        public void IfAPlayerRollsDoublesThreeTimesInARowTheyAutoMaticallyGoToTheJailLocation()
        {

            int count = 0;

            diceMock.Setup(m => m.Roll()).Callback(() => { count++; });
            diceMock.Setup(m => m.GetDiceRollTotal()).Returns(1);
            diceMock.Setup(m => m.LastRollWereAllTheSame()).Returns(true);
            turnEngine = new TurnEngine(diceMock.Object, gameBoard);

            turnEngine.TakeTurn(player);


            Assert.That(player.Location, Is.EqualTo(gameBoard.GetSpaceAddress(gameBoard.Jail)));
        }


        [Test]
        public void IfAPlayerRollsDoublesAndLandsOnGoToJailTheirTurnIsOver()
        {
            player.Location = gameBoard.GetSpaceAddress(gameBoard.GoToJail) - 1;

            int count = 0;

            diceMock.Setup(m => m.Roll()).Callback(() => { count++; });
            diceMock.Setup(m => m.GetDiceRollTotal()).Returns(1);
            diceMock.Setup(m => m.LastRollWereAllTheSame()).Returns(true);
            turnEngine = new TurnEngine(diceMock.Object, gameBoard);

            turnEngine.TakeTurn(player);

            Assert.That(count, Is.EqualTo(1));



        }

        [Test]
        public void IfAPlayerIsInJailIfTheyRollDoublesTheyGetOutOfJail()
        {

            diceMock.Setup(m => m.GetDiceRollTotal()).Returns(1);
            diceMock.Setup(m => m.LastRollWereAllTheSame()).Returns(true);
            turnEngine = new TurnEngine(diceMock.Object, gameBoard);

            gameBoard.Jail.LockUp(player);

            turnEngine.TakeTurn(player);

            Assert.That(!gameBoard.Jail.IsLockedUp(player));

        }


        [Test]
        public void IfAPlayerIsInJailTHeyWillReamainInJailForThreeMoreTurnsIfTheyDontRollDoubles()
        {
            diceMock.Setup(m => m.GetDiceRollTotal()).Returns(1);
            diceMock.Setup(m => m.LastRollWereAllTheSame()).Returns(false);
            turnEngine = new TurnEngine(diceMock.Object, gameBoard);

            gameBoard.Jail.LockUp(player);

            Assert.That(gameBoard.Jail.IsLockedUp(player));

            turnEngine.TakeTurn(player);

            Assert.That(gameBoard.Jail.IsLockedUp(player));

            turnEngine.TakeTurn(player);

            Assert.That(gameBoard.Jail.IsLockedUp(player));
            
        }

        [Test]
        public void IfAPlayerFailsToRollDoublesForThreeTurnsWhileInJailTheMustPay50()
        {
            player.Balence = 50;

            diceMock.Setup(m => m.GetDiceRollTotal()).Returns(1);
            diceMock.Setup(m => m.LastRollWereAllTheSame()).Returns(false);
            turnEngine = new TurnEngine(diceMock.Object, gameBoard);

            gameBoard.Jail.LockUp(player);

            turnEngine.TakeTurn(player);

            Assert.That(gameBoard.Jail.IsLockedUp(player));

            turnEngine.TakeTurn(player);

            Assert.That(gameBoard.Jail.IsLockedUp(player));

            turnEngine.TakeTurn(player);

            Assert.That(!gameBoard.Jail.IsLockedUp(player));

            Assert.That(player.Balence, Is.EqualTo(0));

        }


        [Test]
        public void IfAPlayerIsInJailAndTheyRollDoublesTheyMoveThatManySpaces()
        {

            diceMock.Setup(m => m.GetDiceRollTotal()).Returns(1);
            diceMock.Setup(m => m.LastRollWereAllTheSame()).Returns(true);
            turnEngine = new TurnEngine(diceMock.Object, gameBoard);

            gameBoard.Jail.LockUp(player);

            turnEngine.TakeTurn(player);

            Assert.That(player.Location, Is.EqualTo(gameBoard.GetSpaceAddress(gameBoard.Jail) + 1));
        }

        [Test]
        public void IfAPlayerIsInJailAndTheyRollDoublesTheyDoNotRollAgain()
        {
            int count = 0;

            diceMock.Setup(m => m.Roll()).Callback(() => { count++; });
            diceMock.Setup(m => m.GetDiceRollTotal()).Returns(1);
            diceMock.Setup(m => m.LastRollWereAllTheSame()).Returns(true);
            turnEngine = new TurnEngine(diceMock.Object, gameBoard);

            gameBoard.Jail.LockUp(player);

            turnEngine.TakeTurn(player);

            Assert.That(count, Is.EqualTo(1));
        }
    }
}
