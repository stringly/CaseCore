using CaseCore.Common.Attributes;
using CaseCore.Domain.Common;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using System;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Entity Type that represents a <see cref="CaseAssignment"/> entry associated with a <see cref="Case"></see>
    /// </summary>
    public class CaseAssignment : AuditableEntity
    {
        [IgnoreCodeCoverage]
        private CaseAssignment() { }
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="_case">A <see cref="Entities.Case"/> object.</param>
        /// <param name="assignmentType">A <see cref="Types.CaseAssignmentType"/> object.</param>
        /// <param name="assignedToName">A string containing the username of the user to assign to the case.</param>
        /// <param name="assignmentDate">A <see cref="DateTime"/> representing the date of the assignment.</param>
        /// <param name="remarks">An optional string containing remarks.</param>
        public CaseAssignment(Case _case, CaseAssignmentType assignmentType, string assignedToName, DateTime assignmentDate, string remarks = "")
        {
            Case = _case;
            CaseAssignmentType = assignmentType;
            _assignedToName = assignedToName;
            _assignmentDate = assignmentDate;
            _remarks = remarks;
        }
        /// <summary>
        /// The integer Id of the <see cref="Entities.Case"/> associated with the entry.
        /// </summary>
        public int CaseId { get; private set; }
        /// <summary>
        /// Navigation property to the <see cref="Entities.Case"/> associated with the entry.
        /// </summary>
        public virtual Case Case { get; private set; }
        /// <summary>
        /// The integer Id of the <see cref="Types.CaseAssignmentType"/> associated with the entry.
        /// </summary>
        public int CaseAssignmentTypeId { get; private set; }
        /// <summary>
        /// Navigation property to the <see cref="Types.CaseAssignmentType"/> associated with the entry.
        /// </summary>
        public virtual CaseAssignmentType CaseAssignmentType { get; private set; }
        private readonly string _assignedToName;
        /// <summary>
        /// Returns a string containing the username of the user assigned to the case.
        /// </summary>
        public string AssignedToName => _assignedToName;
        private readonly DateTime _assignmentDate;
        /// <summary>
        /// Returns a <see cref="DateTime"/> that represents the date of the assignment.
        /// </summary>
        public DateTime AssignmentDate => _assignmentDate;
        private string _remarks;
        /// <summary>
        /// A string containing the remarks.
        /// </summary>
        public string Remarks => _remarks;
        /// <summary>
        /// Updates the remarks associated with the record.
        /// </summary>
        /// <param name="newRemarks">A string containing the new remarks.</param>
        /// <exception cref="CaseAssignmentArgumentException">Thrown if the provided parameter is null/whitespace or more than 1000 characters.</exception>

        public void UpdateRemarks(string newRemarks)
        {
            if (string.IsNullOrWhiteSpace(newRemarks))
            {
                throw new CaseAssignmentArgumentException("Cannot update Case Assignment Remarks: parameter cannot be null or whitespace.", nameof(newRemarks));
            }
            else if (newRemarks.Length > 1000)
            {
                throw new CaseAssignmentArgumentException("Cannot update Case Assignment Remarks: parameter must be less than 1000 characters.", nameof(newRemarks));
            }
            _remarks = newRemarks;
        }

    }
}
