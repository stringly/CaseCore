using CaseCore.Common.Attributes;
using CaseCore.Domain.Common;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Class that represents the relationship between a <see cref="Entities.Person"/> object and it's associated <see cref="Entities.PhoneNumber"/>
    /// </summary>
    public class PersonPhoneNumber : BaseEntity
    {
        [IgnoreCodeCoverage]
        private PersonPhoneNumber()
        {
        }
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="person">A <see cref="Entities.Person"/> object.</param>
        /// <param name="phoneNumber">A <see cref="Entities.PhoneNumber"/> object.</param>
        public PersonPhoneNumber(Person person, PhoneNumber phoneNumber)
        {
            Person = person;
            PhoneNumber = phoneNumber;
        }
        /// <summary>
        /// The integer Id of the <see cref="Entities.Person"/> associated with the entry.
        /// </summary>
        public int PersonId { get; set; }
        /// <summary>
        /// Navigation property to the <see cref="Entities.Person"/> associated with the entry.
        /// </summary>
        public Person Person { get; set; }
        /// <summary>
        /// The integer Id of the <see cref="Entities.PhoneNumber"/> associated with the entry.
        /// </summary>
        public int PhoneNumberId { get; set; }
        /// <summary>
        /// Navigation property to the <see cref="Entities.PhoneNumber"/> associated with the entry.
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }
    }
}
