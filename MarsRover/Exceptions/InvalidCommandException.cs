using System;

namespace MarsRover.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException() : base(@"Invalid Command.")
        {
            
        } 
    }
}
