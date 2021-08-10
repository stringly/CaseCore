using System;

namespace CaseCore.Domain.Exceptions.Entities.Address
{
    /// <summary>
    /// Implementation of <see cref="InvalidOperationException"/> used in the <see cref="Domain.Entities.Address"/> class.
    /// </summary>
    public class AddressInvalidOperationException : InvalidOperationException
    {
        /// <summary>
        /// Creates a new Instance of the exception.
        /// </summary>
        /// <param name="message">A string message.</param>
        public AddressInvalidOperationException(string message) : base(message) { }
    }
}
