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
        public ISetup setup;
        public IDice die;


        [SetUp]
        public void MonopolyEngineSetUp()
        {
            setup = new MonopolySetup("Horse", "Car");
            die = new SixSidedDie();
        }

        [Test]
        public void CanMakeNewMonopolyGameWith2Players()
        {
            
            MonopolyEngine game = new MonopolyEngine(setup, die);
            Assert.That(game, Is.Not.Null);
        }


        [Test]
        public void After20RoundsOfMoving_ThePlayOrderShouldNeverChange()
        {

            MonopolyEngine game = new MonopolyEngine(setup,die);

            string player1Name = game.GetCurrentTurnPlayer().name;
            game.TakeTurn();

            string player2Name = game.GetCurrentTurnPlayer().name;
            game.TakeTurn();

            for (int i = 0; i < 19; ++i)
            {
                Assert.That(player1Name, Is.EqualTo(game.GetCurrentTurnPlayer().name));
                game.TakeTurn();

                Assert.That(player2Name, Is.EqualTo(game.GetCurrentTurnPlayer().name));
                game.TakeTurn();
                
            }

        }

        [Test]
        public void PassingGoShouldIncreaseBalenceBy200()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Location = 39;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            var dieMock = new Mock<IDice>();

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            var startingBalence = gameEngine.GetCurrentTurnPlayer().Balence;

            gameEngine.TakeTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer().Balence, Is.EqualTo(startingBalence + 200));

        }

        [Test]
        public void LandingOnGoShouldIncreaseBalenceBy200()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Location = GameBoard.GO_LOCATION-2;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            var dieMock = new Mock<IDice>();

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            var startingBalence = gameEngine.GetCurrentTurnPlayer().Balence;

            gameEngine.TakeTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer().Location, Is.EqualTo(GameBoard.GO_LOCATION));
            Assert.That(gameEngine.GetCurrentTurnPlayer().Balence, Is.EqualTo(startingBalence + 200));
        }

        [Test]
        public void LandingOnGoToJailShouldMoveAPlayerDirectlyToJail()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Location = GameBoard.GO_TO_JAIL_LOCATION - 2;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            var dieMock = new Mock<IDice>();

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            gameEngine.TakeTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer().Location, Is.EqualTo(GameBoard.JAIL_LOCATION)); 
           
        }


        [Test]
        public void LandingOnIncomeTaxWithABalenceLessThen2000ShouldResultIn10PercentDeductionFromBalance()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence = 100;
            player1.Location = GameBoard.INCOME_TAX_LOCATION - 2;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            var dieMock = new Mock<IDice>();

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            var startingBalence = gameEngine.GetCurrentTurnPlayer().Balence;

            gameEngine.TakeTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer().Balence, Is.EqualTo(90));
            

        }

        [Test]
        public void LandingOnIncomeTaxWithABalenceGreaterThan2000ShouldResultIn200DeductionFromBalance()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence =  2200;
            player1.Location = GameBoard.INCOME_TAX_LOCATION-2;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            var dieMock = new Mock<IDice>();

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            var startingBalence = gameEngine.GetCurrentTurnPlayer().Balence;

            gameEngine.TakeTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer().Balence, Is.EqualTo(2000));

        }

        [Test]
        public void LandingOnLuxuryTaxShouldReduceAPlayersBalenceBy75()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence = 100;
            player1.Location = GameBoard.LUXURY_TAX_LOCATION - 2;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            var dieMock = new Mock<IDice>();

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            var startingBalence = gameEngine.GetCurrentTurnPlayer().Balence;

            gameEngine.TakeTurn();

            Assert.That(gameEngine.GetCurrentTurnPlayer().Balence, Is.EqualTo(25));

        }

        [Test]
        public void IfAPlayersBalenceGoesBelowZeroThatPlayerLosses()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence = 0;
            player1.Location = GameBoard.LUXURY_TAX_LOCATION - 2;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            var dieMock = new Mock<IDice>();

            dieMock.Setup(s => s.Roll()).Returns(1);

            MonopolyEngine gameEngine = new MonopolyEngine(setupMock.Object, dieMock.Object);

            var startingBalence = gameEngine.GetCurrentTurnPlayer().Balence;

            gameEngine.TakeTurn();

            Assert.That(gameEngine.CurrentTurnPlayerIsLoser(), Is.True);


        }

    }


}
