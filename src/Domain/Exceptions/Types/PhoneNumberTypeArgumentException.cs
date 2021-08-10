using System;

namespace CaseCore.Domain.Exceptions.Types
{
    /// <summary>
    /// Exception class used in the <see cref="Domain.Types.PhoneNumberType"></see> class.
    /// </summary>
    public class PhoneNumberTypeArgumentException : ArgumentException
    {
        /// <summary>
        /// Creates a new instance of the exception.
        /// </summary>
        /// <param name="message">A string containing the message.</param>
        /// <param name="paramName">A string containing the name of the parameter that threw the exception.</param>
        public PhoneNumberTypeArgumentException(string message, string paramName) : base(message: message, paramName: paramName) { }
    }
}
