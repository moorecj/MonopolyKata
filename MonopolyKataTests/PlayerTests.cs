using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;

namespace MonopolyKataTests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void APlayerMove_ShouldIncreaseTheirLocationByTheNumberOfSpacesMoved()
        {

            MonopolyPlayer player = new MonopolyPlayer("Horse");

            Assert.That(player.Location, Is.EqualTo(0));

            player.Move(6);

            Assert.That(player.Location, Is.EqualTo(6));

        }

        [Test]
        public void APlayerThatMovesBeyondTheLastSpaceOnTheBoard_ShouldLoopAroundToTheBeginingOfBoard()
        {

            MonopolyPlayer player = new MonopolyPlayer("Horse");

            player.Move(39);

            player.Move(6);

            Assert.That(player.Location, Is.EqualTo(5));

        }

        [Test]
        public void APlayerThatGoesOnePositionPastSpace39WillEndUpAtPosition0()
        {
            MonopolyPlayer player = new MonopolyPlayer("Horse");

            player.Move(39);

            player.Move(1);

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
