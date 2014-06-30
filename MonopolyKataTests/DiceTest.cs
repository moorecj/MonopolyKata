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

        [Test]
        public void ADiceRollForShouldBeRandom_Given1000RollsAllSixNumbersShouldAppear()
        {
            IDice die =  new SixSidedDie();
            int[] testRolls =  new int [1000];

            for(int i = 0; i < 1000; ++i)
            {
                testRolls[i] = die.Roll();
            }


            Assert.That(testRolls.Contains(1), Is.True);
            Assert.That(testRolls.Contains(2), Is.True);
            Assert.That(testRolls.Contains(3), Is.True);
            Assert.That(testRolls.Contains(4), Is.True);
            Assert.That(testRolls.Contains(5), Is.True);
            Assert.That(testRolls.Contains(6), Is.True);

        }

    }
}
