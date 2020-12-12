using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    class InvalidCommandException : Exception
    {
        public InvalidCommandException()
        {

        }

        public InvalidCommandException(string message) : base(message)
        {

        }
    }
}
