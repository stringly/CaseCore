using CaseCore.Domain.Common;
using CaseCore.Domain.Exceptions.Types;
using System;

namespace CaseCore.Domain.Types
{
    /// <summary>
    /// Entity class that represents a Status used in a <see cref="Entities.Case"/>
    /// </summary>
    public class CaseStatusType : BaseEntity
    {
        private CaseStatusType() { }
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="statusName">A string containing the status name.</param>
        public CaseStatusType(string statusName)
        {
            UpdateName(statusName);
        }
        private string _name;
        /// <summary>
        /// A string representing the Name of the <see cref="CaseStatusType"/>
        /// </summary>
        /// <remarks>
        /// Field is limited to 25 characters or fewer.
        /// </remarks>
        public string Name => _name;
        /// <summary>
        /// Updates the name of the status.
        /// </summary>
        /// <param name="newName">A string containing a new Name.</param>
        /// <exception cref="CaseStatusTypeArgumentException">Thrown when the provided parameter is null, whitespace, or greater than 25 characters.</exception>

        public void UpdateName(string newName)
        {
            if (String.IsNullOrWhiteSpace(newName))
            {
                throw new CaseStatusTypeArgumentException("Cannot update Case Status Name: parameter cannot be null or whitespace.", nameof(newName));
            }
            else if (newName.Length > 25)
            {
                throw new CaseStatusTypeArgumentException("Cannot update Case Status Name: parameter must be 25 characters or fewer.", nameof(newName));
            }
            _name = newName;
        }
    }
}
