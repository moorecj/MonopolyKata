using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using MonopolyKata;
using MonopolyKata.Player;
using MonopolyKata.Setup;
using MonopolyKata.Cards.WhenDrawnStrategies;


namespace MonopolyKataTests.CardTests.WhenDrawnTests
{
    [TestFixture]
    public class GetFundsFromOtherPlayersTests
    {

        MonopolyPlayer player1 = new MonopolyPlayer("Player1");
        MonopolyPlayer player2 = new MonopolyPlayer("Player2");
        MonopolyPlayer player3 = new MonopolyPlayer("Player2");
        Mock<IPlayerOrderSetup> playerSetupMock;

        [SetUp]
        public void SetUp()
        {

            player1 = new MonopolyPlayer("player1");
            player2 = new MonopolyPlayer("player2");
            player3 = new MonopolyPlayer("player3");

            playerSetupMock = new Mock<IPlayerOrderSetup>();

            playerSetupMock.Setup(s => s.WhoGoesFirst()).Returns(player1);
            playerSetupMock.Setup(s => s.WhoGoesNext(player1)).Returns(player2);
            playerSetupMock.Setup(s => s.WhoGoesNext(player2)).Returns(player3);
            playerSetupMock.Setup(s => s.WhoGoesNext(player3)).Returns(player1);


        }

        [Test]
        public void TheGetFundsFromOthersStrategyWillTakeAnAmmountAndAPlayerOrderSetup()
        {
            int transferAmount = 10;

            GetFundsFromOthersStrategy TansferStrategy = new GetFundsFromOthersStrategy(transferAmount, playerSetupMock.Object);

            Assert.That(TansferStrategy, Is.Not.Null);
        }

        [Test]
        public void TheGetFundsFromOthersStrategyWillRemoveThePastAmmountFromEachPlayer()
        {
            int transferAmount = 10;

            player2.Balence = 10;
            player3.Balence = 10;

            int player2InitialAmount = player2.Balence;
            int player3InitialAmount = player3.Balence;

            GetFundsFromOthersStrategy TansferStrategy = new GetFundsFromOthersStrategy(transferAmount, playerSetupMock.Object);

            TansferStrategy.Apply(player1);

            Assert.That(player2.Balence, Is.EqualTo(player2InitialAmount - transferAmount));
            Assert.That(player3.Balence, Is.EqualTo(player3InitialAmount - transferAmount));
        }

        [Test]
        public void TheGetFundsFromOthersStrategyWillTransferTheAmountFromEachOtherPlayer()
        {
            int transferAmount = 10;

            player1.Balence = 0;
            player2.Balence = 10;
            player3.Balence = 10;

            int player2InitialAmount = player2.Balence;
            int player3InitialAmount = player3.Balence;

            GetFundsFromOthersStrategy TansferStrategy = new GetFundsFromOthersStrategy(transferAmount, playerSetupMock.Object);

            Assert.That(player1.Balence, Is.EqualTo(0));

            TansferStrategy.Apply(player1);

            Assert.That(player1.Balence, Is.EqualTo(player2InitialAmount + player3InitialAmount));
            
        }

        [Test]
        public void IfAPlayerDoesNotHaveEnoughToPayFullAmountAllOfHisFundsAreTransfered()
        {
            int transferAmount = 10;

            player1.Balence = 0;
            player2.Balence = 10;
            player3.Balence = 8;

            int player2InitialAmount = player2.Balence;
            int player3InitialAmount = player3.Balence;

            GetFundsFromOthersStrategy TansferStrategy = new GetFundsFromOthersStrategy(transferAmount, playerSetupMock.Object);

            Assert.That(player1.Balence, Is.EqualTo(0));

            TansferStrategy.Apply(player1);

            Assert.That(player1.Balence, Is.EqualTo(player2InitialAmount + player3InitialAmount));

        }

        [Test]
        public void IfAPlayerDoesNotHaveEnoughToPayFullAmountHisFundsWillGoNegitive()
        {
            int transferAmount = 10;
            int player2InitialAmount = 10;
            int player3InitialAmount = 8;

            player2.Balence = player2InitialAmount;
            player3.Balence = player3InitialAmount;

            PlayerOrderSetup playerSetup = new PlayerOrderSetup(player1, player2, player3);

            GetFundsFromOthersStrategy TansferStrategy = new GetFundsFromOthersStrategy(transferAmount, playerSetupMock.Object);

            TansferStrategy.Apply(player1);

            Assert.That(player3.Balence, Is.LessThan(0));

        }

    }
}
