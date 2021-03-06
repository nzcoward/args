﻿using System;

namespace Args
{
    [Serializable]
    public class InvalidArgsFormatException : Exception
    {
        public InvalidArgsFormatException() { }
        public InvalidArgsFormatException(string message) : base(message) { }
        public InvalidArgsFormatException(string message, Exception inner) : base(message, inner) { }
        protected InvalidArgsFormatException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}