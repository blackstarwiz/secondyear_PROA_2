using System;

namespace SchoolAdmin
{
    [Serializable]
    public class TooYoungException : Exception
    {
        public TooYoungException()
        {
        }

        public TooYoungException(string message) : base(message)
        {
        }

        public TooYoungException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}