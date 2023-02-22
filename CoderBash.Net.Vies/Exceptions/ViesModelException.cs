using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CoderBash.Net.Vies.Exceptions
{
	[ExcludeFromCodeCoverage]
	[Serializable]
	public class ViesModelException : Exception
	{
		public ViesModelException()
		{
		}

        public ViesModelException(string? message) : base(message)
        {
        }

        public ViesModelException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ViesModelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

