using CaseCore.Common.Attributes;
using CaseCore.Domain.Common;
using CaseCore.Domain.Types;
using System;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Class that represents the relationship between a <see cref="Entities.Case"/> object and it's associated <see cref="Type.OffenseType"/>
    /// </summary>
    public class CaseOffense : BaseEntity
    {
        [IgnoreCodeCoverage]
        private CaseOffense() { }
        /// <summary>
        /// Creates a new instance of the class
        /// </summary>
        /// <param name="_case">The <see cref="Case"/> associated with the entry.</param>
        /// <param name="offenseType">The <see cref="OffenseType"/> associated with the entry.</param>
        public CaseOffense(Case _case, OffenseType offenseType)
        {
            Case = _case;
            OffenseType = offenseType;
        }
        /// <summary>
        /// The Id of the <see cref="Entities.Case"/> associated with the record.
        /// </summary>
        public int CaseId { get; private set; }
        /// <summary>
        /// Navigation Property to the <see cref="Entities.Case"/> associated with the record.
        /// </summary>
        public Case Case { get; private set; }
        /// <summary>
        /// The Id of the <see cref="Types.OffenseType"/> associated with the record.
        /// </summary>
        public int OffenseTypeId { get; private set; }
        /// <summary>
        /// Navigation property to the <see cref="Types.OffenseType"/> associated with the record.
        /// </summary>
        public OffenseType OffenseType { get; private set; }



    }
}
