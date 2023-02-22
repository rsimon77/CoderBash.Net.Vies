using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CoderBash.Net.Vies.Exceptions
{
    /// <summary>
    /// Represents a Vies request error.
    /// </summary>
	[ExcludeFromCodeCoverage]
	[Serializable]
	public class ViesRequestException : Exception
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ViesRequestException"/> class.
        /// </summary>
		public ViesRequestException()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ViesRequestException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">Error message</param>
        public ViesRequestException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViesRequestException"/> class with a specified error message and a reference to the inner exception that caused this exception.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">A reference to the inner exception that caused this exception, or null if nothing is specified</param>
        public ViesRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViesRequestException"/> with serialized data
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected ViesRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

