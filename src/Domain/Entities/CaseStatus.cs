using CaseCore.Common.Attributes;
using CaseCore.Domain.Common;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using System;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Entity Type that represents a <see cref="CaseStatus"/> entry associated with a <see cref="Entities.Case"></see>
    /// </summary>
    public class CaseStatus : AuditableEntity
    {
        [IgnoreCodeCoverage]
        private CaseStatus()
        {
        }
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="_case">A <see cref="Entities.Case"/> object.</param>
        /// <param name="caseStatusType">A <see cref="CaseStatusTypeId"/> object.</param>
        /// <param name="statusDate">A <see cref="DateTime"/> representing the effective date of the status entry.</param>
        /// <param name="remarks">A string containing remarks.</param>
        public CaseStatus(Case _case, CaseStatusType caseStatusType, DateTime statusDate, string remarks = "")
        {
            Case = _case;
            CaseStatusType = caseStatusType;
            _statusDate = statusDate;
            _remarks = remarks;
        }        
        /// <summary>
        /// The integer Id of the <see cref="Entities.Case"/> associated with the entry.
        /// </summary>
        public int CaseId { get; private set; }
        /// <summary>
        /// Navigation property to the associated <see cref="Entities.Case"/>
        /// </summary>
        public virtual Case Case { get; private set;}
        /// <summary>
        /// Integer Id of the <see cref="Types.CaseStatusType"/> associated with the entry.
        /// </summary>
        public int CaseStatusTypeId { get; private set; }
        /// <summary>
        /// Navigation property to the <see cref="Types.CaseStatusType"/> associated with the entry.
        /// </summary>
        public CaseStatusType CaseStatusType { get; private set; }
        private readonly DateTime _statusDate;
        /// <summary>
        /// Returns a <see cref="DateTime"/> object representing the effective date of the entry.
        /// </summary>
        public DateTime StatusDate => _statusDate;        
        private string _remarks;
        /// <summary>
        /// Returns a string containing remarks.
        /// </summary>
        public string Remarks => _remarks;
        /// <summary>
        /// Updates the Remarks field for the Status entry.
        /// </summary>
        /// <param name="newRemarks">A string containing the new remarks.</param>
        /// <exception cref="CaseStatusArgumentException">Thrown when the provided parameter is null, whitespace, or greater than 1000 characters.</exception>
        public void UpdateRemarks(string newRemarks)
        {
            if (string.IsNullOrWhiteSpace(newRemarks))
            {
                throw new CaseStatusArgumentException("Cannot update Case Status remarks: parameter cannot be null or whitespace.", nameof(newRemarks));
            }
            else if (newRemarks.Length > 1000)
            {
                throw new CaseStatusArgumentException("Cannot update Case Status remarks: parameter cannot be null or whitespace.", nameof(newRemarks));
            }
            _remarks = newRemarks;
        }
    }
}
