using System;


namespace MarsRover.Exceptions
{
    public class OutOfBorderException : Exception
    {
        public OutOfBorderException() : base(@"Out of Border...")
        {

        }
    }
}
