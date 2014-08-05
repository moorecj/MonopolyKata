using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Player;
using MonopolyKata.Board;
using MonopolyKata.Board.Spaces;
using MonopolyKata.Dice;
using Moq;

namespace MonopolyKataTests.SpaceTests
{
    [TestFixture]
    public class JailSpaceTests
    {

        JailSpace Jail;
        MonopolyGameBoard gameBoard;


        [SetUp]
        public void JailSetUp()
        {
            gameBoard = new MonopolyGameBoard();
            Jail = gameBoard.Jail;
        }
        
        [Test] 
        public void APlayerCanBeLockedInJail()
        {
            MonopolyPlayer player = new MonopolyPlayer("a player");

            Jail.LockUp(player);

            Assert.That(Jail.IsLockedUp(player), Is.EqualTo(true));
        }

        [Test]
        public void APlayerThatIsLockedUpCanBeReleasedFromJail()
        {
            MonopolyPlayer player = new MonopolyPlayer("a player");
            
            Jail.LockUp(player);

            Assert.That(Jail.IsLockedUp(player), Is.EqualTo(true));

            Jail.Release(player);

            Assert.That(Jail.IsLockedUp(player), Is.EqualTo(false));

        }

        [Test]
        public void APlayerThatLandsOnGoToJailShouldGetLockedInJail()
        {
            MonopolyPlayer player = new MonopolyPlayer("a player");

            GoToJailSpace GoToJail = gameBoard.GoToJail;

            GoToJail.LandOn(player);

            Assert.That(Jail.IsLockedUp(player), Is.EqualTo(true));
        }

        [Test]
        public void APlayerLockedInJailCanBeReleasedByRollingDoubles()
        {
            MonopolyPlayer player = new MonopolyPlayer("a player");

            player.Balence = 50;

            Mock<IDice> diceMock = new Mock<IDice>();

            diceMock.Setup(s => s.LastRollWereAllTheSame()).Returns(true);

            Jail.LockUp(player);

            Jail.TryToGetOUtWithDoubles(player, diceMock.Object);

            Assert.That(player.Balence, Is.EqualTo(50));
            Assert.That(Jail.IsLockedUp(player), Is.EqualTo(false));
        }


        [Test]
        public void AJailSpaceWillCountTheNumberOfAttemptsToGetOutByRolling()
        {
            MonopolyPlayer player = new MonopolyPlayer("a player");

            Mock<IDice> diceMock = new Mock<IDice>();

            diceMock.Setup(s => s.LastRollWereAllTheSame()).Returns(false);

            Jail.LockUp(player);
            
            Assert.That(Jail.GetOutFromRollsAttemptCount(player), Is.EqualTo(0));
           
            Jail.TryToGetOUtWithDoubles(player, diceMock.Object);

            Assert.That(Jail.GetOutFromRollsAttemptCount(player), Is.EqualTo(1));
           
            Jail.TryToGetOUtWithDoubles(player, diceMock.Object);

            Assert.That(Jail.GetOutFromRollsAttemptCount(player), Is.EqualTo(2));
            
            Jail.TryToGetOUtWithDoubles(player, diceMock.Object);

            Assert.That(Jail.GetOutFromRollsAttemptCount(player), Is.EqualTo(3));
          
        }

        [Test]
        public void AJailSpaceWillResetTheNumberOfAttemptsToGetOutByRollingWhenThePlayerLeavesJail()
        {
            MonopolyPlayer player = new MonopolyPlayer("a player");

            Mock<IDice> diceMock = new Mock<IDice>();

            diceMock.Setup(s => s.LastRollWereAllTheSame()).Returns(false);

            Jail.LockUp(player);

            Jail.TryToGetOUtWithDoubles(player, diceMock.Object);

            Assert.That(Jail.GetOutFromRollsAttemptCount(player), Is.EqualTo(1));

            Jail.Release(player);

            Assert.That(Jail.GetOutFromRollsAttemptCount(player), Is.EqualTo(0));

        }



    }
}
