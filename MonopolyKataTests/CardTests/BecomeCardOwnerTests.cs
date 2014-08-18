using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Cards.WhenDrawnStrategies;

namespace MonopolyKataTests.CardTests.WhenDrawnTests
{
    [TestFixture]
    public class BecomeCardOwnerTests
    {
        [Test]
        public void AMakePlayerOwnerStrategyShouldNotBeNull()
        {
            IWhenDrawnStrategy makeOwner = new MakePlayerOwnerStrategy();

            Assert.That(makeOwner, Is.Not.Null);
        }
    }
}
