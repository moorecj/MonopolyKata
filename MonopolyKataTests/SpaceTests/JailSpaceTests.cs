using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Player;
using MonopolyKata.Board.Spaces;

namespace MonopolyKataTests.SpaceTests
{
    [TestFixture]
    public class JailSpaceTests
    {
        [Test] 
        public void APlayerCanBeLockedInJail()
        {
            MonopolyPlayer player = new MonopolyPlayer("a player");

            JailSpace Jail = new JailSpace("Jail");
            Jail.LockUp(player);

            Assert.That(Jail.IsLockedUp(player), Is.EqualTo(true));
        }

        [Test]
        public void APlayerThatIsLockedUpCanBeReleasedFromJail()
        {
            MonopolyPlayer player = new MonopolyPlayer("a player");

            JailSpace Jail = new JailSpace("Jail");
            
            Jail.LockUp(player);

            Assert.That(Jail.IsLockedUp(player), Is.EqualTo(true));

            Jail.Release(player);

            Assert.That(Jail.IsLockedUp(player), Is.EqualTo(false));

        }

        [Test]
        public void APlayerThatLandsOnGoToJailShouldGetLockedInJail()
        {
            MonopolyPlayer player = new MonopolyPlayer("a player");

            JailSpace Jail = new JailSpace("Jail");
            GoToJailSpace GoToJail = new GoToJailSpace("Go To Jail", Jail);

            GoToJail.LandOn(player);

            Assert.That(Jail.IsLockedUp(player), Is.EqualTo(true));
        }

        [Test]
        public void APlayerLockedInJailCanPay50ToBeReleasedFromJail()
        {
            MonopolyPlayer player = new MonopolyPlayer("a player");

            player.Balence = 50;

            JailSpace Jail = new JailSpace("Jail");
            GoToJailSpace GoToJail = new GoToJailSpace("Go To Jail", Jail);

            Jail.LockUp(player);

            Jail.Pay50ToGetOut(player);

            Assert.That(player.Balence, Is.EqualTo(0));
            Assert.That(Jail.IsLockedUp(player), Is.EqualTo(false));
        }

        

    }
}
