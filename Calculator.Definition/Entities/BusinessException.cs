using System;
using System.Diagnostics;

namespace Calculator.Definition.Entities
{
    /// <summary>
    /// This class is used to define expected exceptions 
    /// </summary>
    public class BusinessException : Exception
    {
        public TraceLevel TraceLevel { get; set; }

        public BusinessException(TraceLevel traceLevel)
        {
            TraceLevel = traceLevel;
        }

        public BusinessException(string message, TraceLevel traceLevel) : base(message)
        {
            TraceLevel = traceLevel;
        }

        public BusinessException(string message, Exception inner, TraceLevel traceLevel) : base(message, inner)
        {
            TraceLevel = traceLevel;
        }
    }
}
