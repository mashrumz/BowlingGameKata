using BowlingGameKata;
using NUnit.Framework;
using System;

namespace BowlingGameKataTest
{
    public class Tests
    {
        [Test]
        public void InvalidRollTest()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Roll(11));
            Assert.AreEqual("Invalid roll > 10 (Parameter 'pins')", ex.Message);
        }
    }
}