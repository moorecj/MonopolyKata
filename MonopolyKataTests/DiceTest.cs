using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata.Dice;

namespace MonopolyKataTests
{
    [TestFixture]
    class DiceTest
    {
        [Test]
        public void ADiceRollForMonopolyShouldGiveANumberGreaterThen0()
        {
            IDice sixSidedDie = new SixSidedDie();

            Assert.That(sixSidedDie.Roll(), Is.GreaterThan(0));

        }

        [Test]
        public void ADiceRollForMonopolyShouldGiveANumberLessThanOrEqualTo6()
        {
            IDice sixSidedDie = new SixSidedDie();

            Assert.That(sixSidedDie.Roll(), Is.LessThan(7));

        }

    }
}
