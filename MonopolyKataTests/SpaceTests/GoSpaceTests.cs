using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Board.Spaces;
using MonopolyKata.Board;

namespace MonopolyKataTests
{
    [TestFixture]
    public class GoSpaceTests
    {
        [Test]
        public void NoMatterWhichSpaceYouLandOnIfYouPassedGoYouGet200()
        {
            MonopolyPlayer player = new MonopolyPlayer("player1");

            player.Balence = 0;
            player.Location = 39;

            MonopolyBoardSpace space = new MonopolyBoardSpace("A Random Space");

            player.Location = GameBoard.BOARDWALK_LOCATION;

            player.Move(5);

            space.LandOn(player);

            Assert.That(player.Balence, Is.EqualTo(200));
            
        }

        [Test]
        public void LandingOnGoShouldIncreaseBalenceBy200()
        {

            MonopolyPlayer player = new MonopolyPlayer("player1");

            player.Balence = 0;
            player.Location = 0;

            MonopolyBoardSpace space = new GoSpace("A Go Space");

            space.LandOn(player);

            Assert.That(player.Balence, Is.EqualTo(200));
        }
    }
}
