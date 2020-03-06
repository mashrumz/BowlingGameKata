using BowlingGameKata;
using NUnit.Framework;

namespace BowlingGameKataTest
{
    public class FrameTest
    {
        private Frame frame;

        [SetUp]
        public void SetUp()
        {
            frame = new Frame();
        }

        [TestCase((uint)5)]
        [TestCase((uint)6)]
        public void NoMoreThanTenPinsInTwoConsecutiveRolls(uint firstRoll)
        {
            frame.Roll(firstRoll);
            var ex = Assert.Throws<InvalidRollException>(() => frame.Roll(6));
            Assert.AreEqual($"Invalid roll > {10 - firstRoll}", ex.Message);
        }

        [Test]
        public void DoubleStrikeInTheLastFrame()
        {
            frame = new LastFrame();
            frame.Roll(10);
            Assert.DoesNotThrow(() => frame.Roll(10));
        }

        [Test]
        public void InvalidRollAfterDoubleStrikeInTheLastFrame()
        {
            frame = new LastFrame();
            frame.Roll(10);
            frame.Roll(10);
            var ex = Assert.Throws<InvalidRollException>(() => frame.Roll(11));
            Assert.AreEqual($"Invalid roll > 10", ex.Message);
        }
    }
}
