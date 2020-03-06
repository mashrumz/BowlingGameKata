using BowlingGameKata;
using NUnit.Framework;
using System;

namespace BowlingGameKataTest
{
    public class GameTest
    {
        Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [Test]
        public void WhenNoSpareOrStrike_ShouldReturnSumOfPins()
        {
            game.Roll(5);
            game.Roll(4);
            Assert.AreEqual(9, game.Score());
        }

        [Test]
        public void WhenStrikeFollowedByNoSpareOrStrike_ShouldReturnTenPlusSumOfPins()
        {
            game.Roll(10);
            game.Roll(5);
            game.Roll(4);
            Assert.AreEqual(28, game.Score());
        }

        [Test]
        public void WhenSpareFollowedByNoSpareOrStrike_ShouldReturnTenPlusNextRoll()
        {
            game.Roll(9);
            game.Roll(1);
            game.Roll(4);
            game.Roll(5);
            Assert.AreEqual(23, game.Score());
        }

        [Test]
        public void DoubleFollowedByNoSpareOrStrike()
        {
            game.Roll(10);
            game.Roll(10);
            game.Roll(5);
            game.Roll(4);
            Assert.AreEqual(53, game.Score());
        }

        [Test]
        public void TurkeyFollowedByNoSpareOrStrike()
        {
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(5);
            game.Roll(4);
            Assert.AreEqual(83, game.Score());
        }

        [Test]
        public void SpareFollowedByStrikeFollowedByNoSpareOrStrike()
        {
            game.Roll(9);
            game.Roll(1);
            game.Roll(10);
            game.Roll(5);
            game.Roll(4);
            Assert.AreEqual(48, game.Score());
        }

        [Test]
        public void PerfectGame()
        {
            for (var i = 0; i < 12; i++)
            {
                game.Roll(10);
            }
            Assert.AreEqual(300, game.Score());
        }

        [Test]
        public void NoMoreThanTenPins()
        {
            var ex = Assert.Throws<InvalidRollException>(() => game.Roll(11));
            Assert.AreEqual("Invalid roll > 10", ex.Message);
        }

        [Test]
        public void GameOver()
        {
            for (var i = 0; i < 12; i++)
            {
                game.Roll(10);
            }
            var ex = Assert.Throws<InvalidRollException>(() => game.Roll(0));
            Assert.AreEqual("Game over", ex.Message);
        }

        [Test]
        public void NoStrikeOrSpareInLastFrame()
        {
            for (var i = 0; i < 9; i++)
            {
                game.Roll(10);
            }
            game.Roll(0);
            game.Roll(0);
            var ex = Assert.Throws<InvalidRollException>(() => game.Roll(0));
            Assert.AreEqual("Game over", ex.Message);
        }
    }
}
