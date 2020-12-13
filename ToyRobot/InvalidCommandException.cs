using System;

namespace ToyRobot
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException()
        {

        }

        public InvalidCommandException(string message) : base(message)
        {

        }
    }
}
