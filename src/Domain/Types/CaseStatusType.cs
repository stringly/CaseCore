using CaseCore.Domain.Common;
using CaseCore.Domain.Exceptions.Types;
using System;

namespace CaseCore.Domain.Types
{
    public class CaseStatusType : BaseEntity
    {
        private CaseStatusType() { }

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
