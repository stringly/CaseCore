using CaseCore.Domain.Common;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Class that represents a junction between a <see cref="Entities.Person"/> object and it's associated <see cref="Entities.Address"/> objects.
    /// </summary>
    public class PersonAddress : BaseEntity
    {
        private PersonAddress()
        {
        }
        /// <summary>
        /// Creates a new Instance
        /// </summary>
        /// <param name="person">The <see cref="Entities.Person"/> object that owns the Address</param>
        /// <param name="address">The <see cref="Entities.Address"></see> object to add.</param>
        public PersonAddress(Person person, Address address)
        {
            Person = person;
            Address = address;
        }
        /// <summary>
        /// The Id of the <see cref="Entities.Person"/> associated with the PersonAddress entry.
        /// </summary>
        public int PersonId { get; set; }
        /// <summary>
        /// Navigation property to the <see cref="Entities.Person"/> associated with the PersonAddress entry.
        /// </summary>
        public Person Person { get;set; }
        /// <summary>
        /// The Id of the <see cref="Entities.Address"></see> associated with the PersonAddress entry.
        /// </summary>
        public int AddressId { get; set; }
        /// <summary>
        /// Navigation property to the <see cref="Entities.Address"/> associated with the entry.
        /// </summary>
        public Address Address { get; set; }        
    }
}
