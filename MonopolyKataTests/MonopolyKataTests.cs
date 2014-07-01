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
    public class MonopolyKataTests
    {
        [Test]
        public void CanMakeNewMonopolyGameWith2Players()
        {
            ISetup setup = new MonopolySetup("Horse", "Car");
            Monopoly game = new Monopoly(setup);

            Assert.That(game, Is.Not.Null);
        }


        [Test]
        public void After20RoundsOfMoving_ThePlayOrderShouldNeverChange()
        {

            ISetup setup = new MonopolySetup("Horse", "Car");
            Monopoly game = new Monopoly(setup);

            string player1Name = game.GetCurrentTurnPlayer().name;
            game.RollForCurrentTurnPlayer();

            string player2Name = game.GetCurrentTurnPlayer().name;
            game.RollForCurrentTurnPlayer();

            for (int i = 0; i < 19; ++i)
            {
                Assert.That(player1Name, Is.EqualTo(game.GetCurrentTurnPlayer().name));
                game.RollForCurrentTurnPlayer();

                Assert.That(player2Name, Is.EqualTo(game.GetCurrentTurnPlayer().name));
                game.RollForCurrentTurnPlayer();
                
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

            Monopoly game = new Monopoly(setupMock.Object);

            var startingBalence = game.GetCurrentTurnPlayer().Balence;

            game.RollForCurrentTurnPlayer();
            game.RollForCurrentTurnPlayer();


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

            Monopoly game = new Monopoly(setupMock.Object);

            var startingBalence = game.GetCurrentTurnPlayer().Balence;

            game.RollForCurrentTurnPlayer();
            game.RollForCurrentTurnPlayer();

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

            Monopoly game = new Monopoly(setupMock.Object);

            var startingBalence = game.GetCurrentTurnPlayer().Balence;

            game.RollForCurrentTurnPlayer();
            game.RollForCurrentTurnPlayer();

            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(startingBalence));
            Assert.That(game.GetCurrentTurnPlayer().Location, Is.EqualTo(GameBoard.JAIL_LOCATION)); 
           
        }


        [Test]
        public void LandingOnIncomeTaxWithABalenceLessThen2000ShouldResultIn10PercentDeductionFromBalance()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence = 100;

            var setupMock = new Mock<ISetup>();

            setupMock.Setup(s => s.GetDiceRolls()).Returns(1);
            setupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            setupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            setupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player1);

            Monopoly game = new Monopoly(setupMock.Object);

            var startingBalence = game.GetCurrentTurnPlayer().Balence;

            game.RollForCurrentTurnPlayer();
            game.RollForCurrentTurnPlayer();

            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(90));
            

        }





    }


}
