using System;

namespace BowlingGameKata
{
    public class Roll
    {
        public Roll(uint pins)
        {
            if (pins > 10)
            {
                throw new ArgumentException("Invalid roll > 10", nameof(pins));
            }
            this.Pins = pins;
        }

        public uint Pins { get; }
    }
}
