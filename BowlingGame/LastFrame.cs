namespace BowlingGameKata
{
    public class LastFrame : Frame
    {
        protected override bool IsFull => Rolls.Count > 2 || (Rolls.Count == 2 && TotalPins < 10);

        protected bool IsDoubleStrike => Rolls.Count == 2 && TotalPins == 20;
        
        protected override bool IsValidRoll(uint pins)
        {
            var totalPins = TotalPins;
            if (totalPins + pins <= 10 
                || (pins <= 10 && (IsSpareOrStrike || IsDoubleStrike)))
            {
                return true;
            }
            return false;
        }

        protected override uint MaxValidRoll
        {
            get
            {
                if (IsDoubleStrike || IsSpareOrStrike)
                    return 10;
                return 10 - TotalPins;
            }
        }
    }
}
