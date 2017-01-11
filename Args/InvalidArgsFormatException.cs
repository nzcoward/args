using System;
using System.Runtime.Serialization;

namespace Args
{
    [Serializable]
    public class InvalidArgsFormatException : Exception
    {
        public InvalidArgsFormatException() { }
        public InvalidArgsFormatException(string message) : base(message) { }
        public InvalidArgsFormatException(string message, Exception inner) : base(message, inner) { }
        protected InvalidArgsFormatException(SerializationInfo info, StreamingContext context)
            : base(string.Format("{0}: {1}", context, info)) { }
    }
}