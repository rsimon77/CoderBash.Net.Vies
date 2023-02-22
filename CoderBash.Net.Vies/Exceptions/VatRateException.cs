using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CoderBash.Net.Vies.Exceptions
{
	/// <summary>
	/// Represents a Vat Rate error.
	/// </summary>
	[ExcludeFromCodeCoverage]
	[Serializable]
	public class VatRateException : Exception
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="VatRateException"/> class.
        /// </summary>
        public VatRateException()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="VatRateException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">Error message</param>
        public VatRateException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VatRateException"/> class with a specified error message and a reference to the inner exception that caused this exception.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">A reference to the inner exception that caused this exception, or null if nothing is specified</param>
        public VatRateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VatRateException"/> with serialized data
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected VatRateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

