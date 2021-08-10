using System;

namespace CaseCore.Domain.Exceptions.Entities
{
    /// <summary>
    /// Implementation of <see cref="ArgumentException"/> used in the <see cref="Domain.Entities.CaseStatus"/> class.
    /// </summary>
    public class CaseStatusArgumentException : ArgumentException
    {
        /// <summary>
        /// Creates a new instance of the exception.
        /// </summary>
        /// <param name="message">A string containing the message.</param>
        /// <param name="paramName">A string containing the name of the parameter that threw the exception.</param>
        public CaseStatusArgumentException(string message, string paramName) : base(message: message, paramName: paramName) { }
    }
}
