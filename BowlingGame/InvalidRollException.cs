using System;

namespace BowlingGameKata
{
    public class InvalidRollException : ApplicationException
    {
        public InvalidRollException(string message) : base(message)
        {
        }

        public InvalidRollException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
