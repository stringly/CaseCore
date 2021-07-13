using CaseCore.Domain.Common;

namespace CaseCore.Domain.Entities
{
    public class PersonAddress : BaseEntity
    {
        private PersonAddress() { }
        public PersonAddress(Address address)
        {
            Address = address;
        }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
