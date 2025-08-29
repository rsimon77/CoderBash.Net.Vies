using System;
using System.Diagnostics.CodeAnalysis;

namespace CoderBash.Net.Vies.Exceptions
{
    /// <summary>
    /// Represents a Vies model error.
    /// </summary>
	[ExcludeFromCodeCoverage]
	public class ViesModelException : Exception
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ViesModelException"/> class.
        /// </summary>
		public ViesModelException()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ViesModelException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">Error message</param>
        public ViesModelException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViesModelException"/> class with a specified error message and a reference to the inner exception that caused this exception.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">A reference to the inner exception that caused this exception, or null if nothing is specified</param>
        public ViesModelException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

