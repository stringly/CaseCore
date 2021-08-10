using CaseCore.Common.Attributes;
using CaseCore.Domain.Common;
using CaseCore.Domain.Exceptions.Types;
using System;

namespace CaseCore.Domain.Types
{
    /// <summary>
    /// Class that represents a type of assignment entry associated with a <see cref="Domain.Entities.CaseAssignment"/>
    /// </summary>
    public class CaseAssignmentType : BaseEntity
    {
        [IgnoreCodeCoverage]
        private CaseAssignmentType() { }
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="assignmentTypeName">A string representing the type name.</param>
        /// <exception cref="CaseAssignmentTypeArgumentException">Thrown when the provided parameter is null, whitespace, or more than 25 characters.</exception>
        public CaseAssignmentType(string assignmentTypeName)
        {
            UpdateName(assignmentTypeName);
        }
        private string _name;
        /// <summary>
        /// Returns a string representing the name of the Type.
        /// </summary>
        public string Name => _name;
        /// <summary>
        /// Updates the name of the type.
        /// </summary>
        /// <param name="newName">A string representing the new name.</param>
        /// <exception cref="CaseAssignmentTypeArgumentException">Thrown when the provided parameter is null, whitespace, or greater than 25 characters.</exception>
        public void UpdateName(string newName)
        {
            if (String.IsNullOrWhiteSpace(newName))
            {
                throw new CaseAssignmentTypeArgumentException("Cannot update Case Assignment Type Name: parameter cannot be null or whitespace.", nameof(newName));
            }
            else if (newName.Length > 25)
            {
                throw new CaseAssignmentTypeArgumentException("Cannot update Case Assignment Type Name: parameter must be 25 characters or fewer.", nameof(newName));
            }
            _name = newName;
        }
    }
}
