using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata;
using MonopolyKata.Player;
using NUnit.Framework;
using MonopolyKata.Setup;
using Moq;
using MonopolyKata.Board;
using MonopolyKata.Dice;

namespace MonopolyKataTests
{
    [TestFixture]
    public class MonopolyEngineTests
    {
        public Mock<ISetup> setupMock;
        public Mock<IDie> dieMock;
        MonopolyPlayer player1;
        MonopolyPlayer player2;
        IMonopolyGameBoard gameBoard;

        [SetUp]
        public void MonopolyEngineSetUp()
        {

            player1 = new MonopolyPlayer("player1");
            player2 = new MonopolyPlayer("player2");

            setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            dieMock = new Mock<IDie>();

            gameBoard = new MonopolyGameBoard();
            
        }

        [Test]
        public void CanMakeNewMonopolyGameWith2Players()
        {

            MonopolyEngine game = new MonopolyEngine(setupMock.Object, dieMock.Object);
            Assert.That(game, Is.Not.Null);
        }


        [Test]
        public void After20RoundsOfMoving_ThePlayOrderShouldNeverChange()
        {
            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine game = new MonopolyEngine(setupMock.Object,dieMock.Object);

            string player1Name = game.GetCurrentTurnPlayer().name;
            game.GoToNextTurn();

            string player2Name = game.GetCurrentTurnPlayer().name;
            game.GoToNextTurn();

            Assert.That(player1Name, Is.Not.EqualTo(player2Name));

            for (int i = 0; i < 19; ++i)
            {
                Assert.That(player1Name, Is.EqualTo(game.GetCurrentTurnPlayer().name));
                game.GoToNextTurn();

                Assert.That(player2Name, Is.EqualTo(game.GetCurrentTurnPlayer().name));
                game.GoToNextTurn();
                
            }

        }


        [Test]
        public void LandingOnGoToJailShouldMoveAPlayerDirectlyToJail()
        {
            dieMock.Setup(s => s.Roll()).Returns(1);

            player1.Location = gameBoard.GetSpaceAddress(gameBoard.GoToJail) - 2;

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer().Location, Is.EqualTo(gameBoard.GetSpaceAddress(gameBoard.Jail))); 
           
        }


        [Test]
        public void IfAPlayersBalenceGoesBelowZeroThatPlayerLosses()
        {

            player1.Balence = 0;
            player1.Location = gameBoard.GetSpaceAddress(gameBoard.LuxuryTax) - 2;

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            int startingBalence = gameEngine.GetCurrentTurnPlayer().Balence;

            gameEngine.TakeTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsLoser(), Is.True);

        }

        [Test]
        public void IfAPlayerLosesThePlayerShouldRemovedFromTheTurnRotaion()
        {

            MonopolyPlayer player3 = new MonopolyPlayer("player3");

            player1.Balence = 0;
            player1.Location = gameBoard.GetSpaceAddress(gameBoard.LuxuryTax) - 2;

            dieMock.Setup(s => s.Roll()).Returns(1);

            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player3);
            setupMock.Setup(s => s.WhoGoesNext(player3)).Returns(player1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            int startingBalence = gameEngine.GetCurrentTurnPlayer().Balence;

            gameEngine.TakeTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsLoser(), Is.True);

            gameEngine.GoToNextTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer(), Is.EqualTo(player2));

            gameEngine.GoToNextTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer(), Is.EqualTo(player3));

            gameEngine.GoToNextTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer(), Is.EqualTo(player2));

        }

        [Test]
        public void IfAPlayerLosesTheOthersPlayersInTheGameShouldBeAllowedToContinuePlay()
        {
            MonopolyPlayer player3 = new MonopolyPlayer("player3");

            player1.Balence = 0;
            player1.Location = gameBoard.GetSpaceAddress(gameBoard.LuxuryTax) - 2;

            dieMock.Setup(s => s.Roll()).Returns(1);

            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player3);
            setupMock.Setup(s => s.WhoGoesNext(player3)).Returns(player1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            int startingBalence = gameEngine.GetCurrentTurnPlayer().Balence;

            gameEngine.TakeTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsLoser(), Is.True);

            gameEngine.GoToNextTurn();
            gameEngine.TakeTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsWinner(), Is.False);
            Assert.That(gameEngine.GetCurrentTurnPlayer(), Is.EqualTo(player2));

            gameEngine.GoToNextTurn();
            gameEngine.TakeTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsWinner(), Is.False);
            Assert.That(gameEngine.GetCurrentTurnPlayer(), Is.EqualTo(player3));
            
            gameEngine.GoToNextTurn();
            gameEngine.TakeTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsWinner(), Is.False);
            Assert.That(gameEngine.GetCurrentTurnPlayer(), Is.EqualTo(player2));

        }

        [Test]
        public void IfAPlayerIsTheOnlyPlayerLeftInTheGameAndThatHasNotLostThatPlayerIsTheWinner()
        {

            player1.Balence = 0;
            player1.Location = gameBoard.GetSpaceAddress(gameBoard.LuxuryTax) - 2;

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsLoser(), Is.True);

            gameEngine.GoToNextTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsWinner(), Is.True);

        }

        [Test]
        public void APlayerIsNotTheWinnerIfTheyRollDoubles()
        {
            player1.Balence = 0;
            player1.Location = gameBoard.GetSpaceAddress(gameBoard.FreeParking) - 2;

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsWinner(), Is.False);
        }

  

    }


}
