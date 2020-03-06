using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata
{
    public class Game
    {
        Frame currentFrame = null;
        readonly IList<Frame> frames = new List<Frame>(10);

        public Game()
        {
            for (var i = 0; i < 9; i++)
            {
                var frame = new Frame();
                frames.Add(frame);
                if (i > 0)
                {
                    frames[i - 1].NextFrame = frame;
                }
            }
            var lastFrame = new LastFrame();
            frames.Last().NextFrame = lastFrame;
            frames.Add(lastFrame);
            currentFrame = frames[0];
        }

        public void Roll(uint pins)
        {
            if (IsGameOver)
            {
                throw new InvalidRollException("Game over");
            }

            currentFrame = currentFrame.Roll(pins);            
        }

        private bool IsGameOver
        {
            get
            {
                return currentFrame == null;
            }
        }

        public uint Score()
        {
            return (uint)frames.Sum(f => f.Score());
        }
    }
}
