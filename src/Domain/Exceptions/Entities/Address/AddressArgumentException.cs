using System;

namespace CaseCore.Domain.Exceptions.Entities.Address
{
    /// <summary>
    /// Exception class used in the <see cref="Domain.Types.AddressType"></see> class.
    /// </summary>
    public class AddressArgumentException : ArgumentException
    {
        /// <summary>
        /// Creates a new instance of the exception.
        /// </summary>
        /// <param name="message">A string containing the message.</param>
        /// <param name="paramName">A string containing the name of the parameter that threw the exception.</param>
        public AddressArgumentException(string message, string paramName) : base(message: message, paramName: paramName) { }
    }
}
