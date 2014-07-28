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

            player1.Location = GameBoard.GO_TO_JAIL_LOCATION - 2;

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer().Location, Is.EqualTo(GameBoard.JAIL_LOCATION)); 
           
        }


        [Test]
        public void IfAPlayersBalenceGoesBelowZeroThatPlayerLosses()
        {

            player1.Balence = 0;
            player1.Location = GameBoard.LUXURY_TAX_LOCATION - 2;

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            int startingBalence = gameEngine.GetCurrentTurnPlayer().Balence;

            gameEngine.TakeTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsLoser(), Is.True);

        }

        [Test]
        public void IfAPlayerLosesThePlayerShouldRemovedFromTheTurnRotaion()
        {

            player1.Balence = 0;
            player1.Location = GameBoard.LUXURY_TAX_LOCATION - 2;

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            int startingBalence = gameEngine.GetCurrentTurnPlayer().Balence;

            gameEngine.TakeTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsLoser(), Is.True);

            gameEngine.GoToNextTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer(), Is.Not.EqualTo(player1));

            gameEngine.GoToNextTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer(), Is.Not.EqualTo(player1));

        }

        [Test]
        public void IfAPlayerLosesTheOthersPlayersInTheGameShouldBeAllowedToContinuePlay()
        {
            MonopolyPlayer player3 = new MonopolyPlayer("player3");

            player1.Balence = 0;
            player1.Location = GameBoard.LUXURY_TAX_LOCATION - 2;

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

            Assert.That(gameEngine.GetCurrentTurnPlayer(), Is.Not.EqualTo(player1));

            gameEngine.GoToNextTurn();
            gameEngine.TakeTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer(), Is.Not.EqualTo(player1));
            
            gameEngine.GoToNextTurn();
            gameEngine.TakeTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer(), Is.Not.EqualTo(player1));

        }

        [Test]
        public void IfAPlayerIsTheOnlyPlayerLeftInTheGameThatHasNotLostThatPlayerIsTheWinner()
        {

            player1.Balence = 0;
            player1.Location = GameBoard.LUXURY_TAX_LOCATION - 2;

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
            player1.Location = GameBoard.FREE_PARKING_LOCATION - 2;

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsWinner(), Is.False);
        }

        [Test]
        public void IfAPlayerRollsDoublesThenTheyGetToRollAgain()
        {
            int count = 0;
            
            dieMock.Setup(m => m.Roll()).Returns(1).Callback(() => { count++; });

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);      

            gameEngine.TakeTurn();

            Assert.That(count, Is.GreaterThan(2));

        }

        [Test]
        public void IfAPlayerDoesNotRollDoublesThenTheyDoNotRollAgain()
        {
            int count = 0;
            int roll  = 1;

            const int NumberOfDieRollsPerMove = 2;

            dieMock.Setup(m => m.Roll()).Returns(() => roll).Callback(() => { count++; roll++; });

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();

            Assert.That(count, Is.EqualTo(NumberOfDieRollsPerMove));

        }


        [Test]
        public void IfAPlayerRollsDoublesThreeTimesInARowTheyAutoMaticallyGoToTheJailLocation()
        {

            MonopolyPlayer player;

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            player = gameEngine.GetCurrentTurnPlayer();

            gameEngine.TakeTurn();

            Assert.That(player.Location, Is.EqualTo(GameBoard.JAIL_LOCATION));
        }


        [Test]
        public void IfAPlayerRollsDoublesAndLandsOnGoToJailTheirTurnIsOver()
        {
            player1.Location = GameBoard.GO_TO_JAIL_LOCATION-2;
            
            int count = 0;

            dieMock.Setup(m => m.Roll()).Returns(1).Callback(() => { count++; });

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();

            Assert.That(count, Is.EqualTo(2));

        }

        [Test]
        public void IfAPlayerIsInJailIfTheyRollDoublesTheyGetOutOfJail()
        {
            player1.Location = GameBoard.GO_TO_JAIL_LOCATION - 2;

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();
            
            Assert.That(gameEngine.gameBoard.Jail.IsLockedUp(gameEngine.GetCurrentTurnPlayer()));
            
            gameEngine.GoToNextTurn();

            gameEngine.GoToNextTurn();
            gameEngine.TakeTurn();
            Assert.That(!gameEngine.gameBoard.Jail.IsLockedUp(gameEngine.GetCurrentTurnPlayer()));

        }


        [Test]
        public void IfAPlayerIsInJailTHeyWillReamainInJailForThreeMoreTurnsIfTheyDontRollDoubles()
        {
            player1.Location = GameBoard.GO_TO_JAIL_LOCATION - 3;
            int roll = 1;

            dieMock.Setup(m => m.Roll()).Returns(() => roll).Callback(() => { roll++; });

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();
            Assert.That(gameEngine.gameBoard.Jail.IsLockedUp(gameEngine.GetCurrentTurnPlayer()));
           
            gameEngine.GoToNextTurn();
            gameEngine.GoToNextTurn();


            Assert.That(gameEngine.gameBoard.Jail.IsLockedUp(gameEngine.GetCurrentTurnPlayer()));
            gameEngine.TakeTurn();
            
            gameEngine.GoToNextTurn();
            gameEngine.GoToNextTurn();

            Assert.That(gameEngine.gameBoard.Jail.IsLockedUp(gameEngine.GetCurrentTurnPlayer()));

            gameEngine.GoToNextTurn();
            gameEngine.GoToNextTurn();

            Assert.That(gameEngine.gameBoard.Jail.IsLockedUp(gameEngine.GetCurrentTurnPlayer()));
        }

        [Test]
        public void IfAPlayerFailsToRollDoublesForThreeTurnsWhileInJailTheMustPay50()
        {
            player1.Location = GameBoard.GO_TO_JAIL_LOCATION - 3;
            int roll = 1;

            player1.Balence = 50;

            dieMock.Setup(m => m.Roll()).Returns(() => roll).Callback(() => { roll++; });

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();

            gameEngine.GoToNextTurn();
            gameEngine.GoToNextTurn();

            gameEngine.TakeTurn();

            gameEngine.GoToNextTurn();
            gameEngine.GoToNextTurn();

            gameEngine.TakeTurn();

            gameEngine.GoToNextTurn();
            gameEngine.GoToNextTurn();

            gameEngine.TakeTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer().Balence, Is.EqualTo(0));

        }


        [Test]
        public void IfAPlayerIsInJailAndTheyRollDoublesTheyMoveThatManySpaces()
        {

            player1.Location = GameBoard.GO_TO_JAIL_LOCATION - 2;

            int count = 0;

            dieMock.Setup(m => m.Roll()).Returns(1).Callback(() => { count++; });

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();

            gameEngine.GoToNextTurn();
            gameEngine.GoToNextTurn();

            count = 0;
            gameEngine.TakeTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer().Location, Is.EqualTo(GameBoard.JAIL_LOCATION+2));
            

        }

        [Test]
        public void IfAPlayerIsInJailAndTheyRollDoublesTheyDoNotRollAgain()
        {
            player1.Location = GameBoard.GO_TO_JAIL_LOCATION - 2;

            int count = 0;

            const int NumberOfDieRollsPerMove = 2;

            dieMock.Setup(m => m.Roll()).Returns(1).Callback(() => { count++; });

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();

            gameEngine.GoToNextTurn();
            gameEngine.GoToNextTurn();

            count = 0;
            gameEngine.TakeTurn();

            Assert.That(count, Is.EqualTo(NumberOfDieRollsPerMove));


        }

    }


}
