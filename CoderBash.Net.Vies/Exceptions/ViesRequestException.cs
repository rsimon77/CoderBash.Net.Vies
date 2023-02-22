using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CoderBash.Net.Vies.Exceptions
{
	[ExcludeFromCodeCoverage]
	[Serializable]
	public class ViesRequestException : Exception
	{
		public ViesRequestException()
		{
		}

        public ViesRequestException(string? message) : base(message)
        {
        }

        public ViesRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ViesRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

