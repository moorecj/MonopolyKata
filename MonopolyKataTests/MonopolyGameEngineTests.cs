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

namespace MonopolyKataTests
{
    [TestFixture]
    public class MonopolyGameEngineTests
    {
        [Test]
        public void CanMakeNewMonopolyGameWith2Players()
        {
            ISetup setup = new MonopolySetup("Horse", "Car");
            MonopolyEngine game = new MonopolyEngine(setup);

            Assert.That(game, Is.Not.Null);
        }


        [Test]
        public void After20RoundsOfMoving_ThePlayOrderShouldNeverChange()
        {

            ISetup setup = new MonopolySetup("Horse", "Car");
            MonopolyEngine game = new MonopolyEngine(setup);

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

            setupMock.Setup(s => s.GetDiceRolls()).Returns(10);
            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            MonopolyEngine game = new MonopolyEngine(setupMock.Object);

            var startingBalence = game.GetCurrentTurnPlayer().Balence;

            game.TakeTurn();
            game.TakeTurn();


            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(startingBalence + 200));

        }

        [Test]
        public void LandingOnGoShouldIncreaseBalenceBy200()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Location = 39;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.GetDiceRolls()).Returns(1);
            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            MonopolyEngine game = new MonopolyEngine(setupMock.Object);

            var startingBalence = game.GetCurrentTurnPlayer().Balence;

            game.TakeTurn();
            game.TakeTurn();

            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(startingBalence + 200));
        }

        [Test]
        public void LandingOnGoToJailShouldMoveAPlayerDirectlyToJail()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Location = GameBoard.MARVIN_GARDINS_AVENUE_LOCATION;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.GetDiceRolls()).Returns(1);
            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            MonopolyEngine game = new MonopolyEngine(setupMock.Object);

            var startingBalence = game.GetCurrentTurnPlayer().Balence;

            game.TakeTurn();
            game.TakeTurn();

            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(startingBalence));
            Assert.That(game.GetCurrentTurnPlayer().Location, Is.EqualTo(GameBoard.JAIL_LOCATION)); 
           
        }


        [Test]
        public void LandingOnIncomeTaxWithABalenceLessThen2000ShouldResultIn10PercentDeductionFromBalance()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence = 100;
            player1.Location = GameBoard.BALTIC_AVENUE_LOCATION;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.GetDiceRolls()).Returns(1);
            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            MonopolyEngine game = new MonopolyEngine(setupMock.Object);

            var startingBalence = game.GetCurrentTurnPlayer().Balence;

            game.TakeTurn();
            game.TakeTurn();

            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(90));
            

        }

        [Test]
        public void LandingOnIncomeTaxWithABalenceGreaterThan2000ShouldResultIn200DeductionFromBalance()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence =  2200;
            player1.Location = GameBoard.BALTIC_AVENUE_LOCATION;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.GetDiceRolls()).Returns(1);
            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            MonopolyEngine game = new MonopolyEngine(setupMock.Object);

            var startingBalence = game.GetCurrentTurnPlayer().Balence;

            game.TakeTurn();
            game.TakeTurn();

            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(2000));


        }

        [Test]
        public void LandingOnLuxuryTaxShouldReduceAPlayersBalenceBy75()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence = 100;
            player1.Location = GameBoard.PARK_PLACE_LOCATION;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.GetDiceRolls()).Returns(1);
            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            MonopolyEngine game = new MonopolyEngine(setupMock.Object);

            var startingBalence = game.GetCurrentTurnPlayer().Balence;

            game.TakeTurn();
            game.TakeTurn();

            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(25));


        }

    }


}
