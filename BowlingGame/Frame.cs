using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata
{
    public class Frame
    {
        public Frame()
        {
            Rolls = new List<Roll>(2);
        }

        public Frame NextFrame { get; set; }

        public IList<Roll> Rolls { get; }

        public uint Score()
        {
            if (IsSpareOrStrike)
            {
                var score = 10 + NextFrame.Rolls[0].Pins;
                if (Rolls.Count == 1)
                {
                    if (NextFrame.Rolls.Count == 1)
                    {
                        score += NextFrame.NextFrame.Rolls[0].Pins;
                    }
                    else
                    {
                        score += NextFrame.Rolls[1].Pins;
                    }
                }
                return score;
            }

            return TotalPins;
        }

        public uint TotalPins => (uint)Rolls.Sum(r => r.Pins);

        public Frame Roll(uint pins)
        {
            if (IsFull)
            {
                if (NextFrame != null)
                {
                    return NextFrame.Roll(pins);
                }

                return null;
            }

            if (!IsValidRoll(pins))
            {
                throw new InvalidRollException($"Invalid roll > {MaxValidRoll}");
            }

            var roll = new Roll(pins);
            Rolls.Add(roll);

            if (IsFull)
            {
                return NextFrame;
            }

            return this;
        }

        protected virtual bool IsFull
        {
            get
            {
                return Rolls.Count > 1 || IsSpareOrStrike;
            }
        }

        protected virtual bool IsValidRoll(uint pins) => TotalPins + pins <= 10;

        protected virtual uint MaxValidRoll => 10 - TotalPins;

        public bool IsSpareOrStrike => TotalPins == 10;

        public bool IsLast => NextFrame == null;
    }
}
