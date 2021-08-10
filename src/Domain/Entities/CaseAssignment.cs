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
        public string AssignedToName => _assignedToName;
        private readonly DateTime _assignmentDate;
        public DateTime AssignmentDate => _assignmentDate;
        private string _remarks;
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
