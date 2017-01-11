using System;
using System.Runtime.Serialization;

namespace Args
{
    [Serializable]
    public class BindingDefinitionException : Exception
    {
        public BindingDefinitionException() { }
        public BindingDefinitionException(string message) : base(message) { }
        public BindingDefinitionException(string message, Exception inner) : base(message, inner) { }
        protected BindingDefinitionException(SerializationInfo info, StreamingContext context)
            : base(string.Format("{0}: {1}", context, info)) { }
    }
}
