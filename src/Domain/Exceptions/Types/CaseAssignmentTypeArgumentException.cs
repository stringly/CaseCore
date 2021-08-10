using System;
using System.Collections.Generic;
using System.Text;

namespace CaseCore.Domain.Exceptions.Types
{
    /// <summary>
    /// Exception class used in the <see cref="Domain.Types.CaseAssignmentType"></see> class.
    /// </summary>
    public class CaseAssignmentTypeArgumentException : ArgumentException
    {
        /// <summary>
        /// Creates a new instance of the exception.
        /// </summary>
        /// <param name="message">A string containing the message.</param>
        /// <param name="paramName">A string containing the name of the parameter that threw the exception.</param>
        public CaseAssignmentTypeArgumentException(string message, string paramName) : base(message: message, paramName: paramName) { }
    }
}
