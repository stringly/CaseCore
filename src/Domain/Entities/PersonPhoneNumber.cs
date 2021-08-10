using CaseCore.Common.Attributes;
using CaseCore.Domain.Common;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Class that represents the relationship between a <see cref="Person"/> object and it's associated <see cref="PhoneNumber"/>
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
        /// <param name="person">A <see cref="Person"/> object.</param>
        /// <param name="phoneNumber">A <see cref="PhoneNumber"/> object.</param>
        public PersonPhoneNumber(Person person, PhoneNumber phoneNumber)
        {
            Person = person;
            PhoneNumber = phoneNumber;
        }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
    }
}
