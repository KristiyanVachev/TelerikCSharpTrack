using System;

namespace Range_Exceptions
{
    public class InvalidRangeException : ApplicationException
    {
        public InvalidRangeException(string msg) : base(msg)
        {

        }

        public InvalidRangeException(string msg, Exception innerEx) : base(msg, innerEx)
        {

        }
    }
}