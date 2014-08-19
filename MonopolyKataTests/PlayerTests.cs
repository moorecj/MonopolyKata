using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using MonopolyKata;
using MonopolyKata.Player;
using MonopolyKata.Board;
using MonopolyKata.Cards;
using MonopolyKata.Cards.WhenDrawnStrategies;

namespace MonopolyKataTests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void APlayerMove_ShouldIncreaseTheirLocationByTheNumberOfSpacesMoved()
        {
            MonopolyGameBoard board = new MonopolyGameBoard();
            MonopolyPlayer player = new MonopolyPlayer("Horse");

            Assert.That(player.Location, Is.EqualTo(0));

            board.Move(player, 6);

            Assert.That(player.Location, Is.EqualTo(6));
        }

        [Test]
        public void APlayerThatMovesBeyondTheLastSpaceOnTheBoard_ShouldLoopAroundToTheBeginingOfBoard()
        {
            MonopolyGameBoard board = new MonopolyGameBoard();
            MonopolyPlayer player = new MonopolyPlayer("Horse");

            player.Location = 39;
            
            board.Move(player,6);

            Assert.That(player.Location, Is.EqualTo(5));

        }

        [Test]
        public void APlayerThatGoesOnePositionPastSpace39WillEndUpAtPosition0()
        {
            MonopolyGameBoard board = new MonopolyGameBoard();
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

        [Test]
        public void APlayerShouldHaveNoCardsToStart()
        {
            MonopolyPlayer player = new MonopolyPlayer("Horse");
            Assert.That(player.GetNumberOfCards(), Is.EqualTo(0));
        }

        [Test]
        public void IfAPlayerHasNoCardsTheGetCardFunctionShouldReturnNull()
        {
            MonopolyPlayer player = new MonopolyPlayer("Horse");

            ICard card;

            card = player.GetCardByIndex(0);

            Assert.That(card, Is.EqualTo(null));
        }

        [Test]
        public void IfAPlayerHasACardAddedTheCardCountShouldIncreaseByOne()
        {
            MonopolyPlayer player = new MonopolyPlayer("Horse");

            ICard card;

            card = new Card("test", Moq.It.IsAny<IWhenDrawnStrategy>());

            Assert.That(player.GetNumberOfCards(), Is.EqualTo(0));

            player.AddCard(card);

            Assert.That(player.GetNumberOfCards(), Is.EqualTo(1));
        }

        [Test]
        public void IfAPlayerHasACardRemovedTheCardCountShouldDecreaseByOne()
        {
            MonopolyPlayer player = new MonopolyPlayer("Horse");

            ICard card;

            card = new Card("test", Moq.It.IsAny<IWhenDrawnStrategy>());

            player.AddCard(card);

            Assert.That(player.GetNumberOfCards(), Is.EqualTo(1));

            player.RemoveCard(card);

            Assert.That(player.GetNumberOfCards(), Is.EqualTo(0));
        }

        [Test]
        public void IfAPlayerTryToRemovedACardThatItDoesNotHaveTheCountWillRemainUnchanged()
        {
            MonopolyPlayer player = new MonopolyPlayer("Horse");

            ICard card1 = new Card("test", Moq.It.IsAny<IWhenDrawnStrategy>());
            ICard card2 = new Card("test", Moq.It.IsAny<IWhenDrawnStrategy>());

            player.AddCard(card1);

            Assert.That(player.GetNumberOfCards(), Is.EqualTo(1));

            player.RemoveCard(card2);

            Assert.That(player.GetNumberOfCards(), Is.EqualTo(1));
        }


      
    }
}
