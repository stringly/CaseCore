using CaseCore.Common.Attributes;
using CaseCore.Domain.Common;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Class that represents the relationship between a <see cref="Entities.Case"/> object and it's associated <see cref="Entities.Address"/>
    /// </summary>
    [IgnoreCodeCoverage]
    public class CaseAddress : BaseEntity
    {
        
        private CaseAddress() { }
        public CaseAddress(Case _case, Address address)
        {
            Case = _case;
            Address = address;
        }
        /// <summary>
        /// Integer ID of the <see cref="Entities.Case"/> entity associated with this Case.
        /// </summary>
        public int CaseId { get; private set; }
        /// <summary>
        /// Navigation property for the associated <see cref="Entities.Case"/>
        /// </summary>
        public Case Case { get; private set; }
        /// <summary>
        /// Integer ID of the <see cref="Entities.Address"/> entity associated with this Case.
        /// </summary>
        public int AddressId { get; private set; }
        /// <summary>
        /// Navigation property for the associated <see cref="Entities.Address"/>
        /// </summary>
        public Address Address { get; private set; }
    }
}
