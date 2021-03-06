using CaseCore.Common.Attributes;
using CaseCore.Domain.Common;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Class that represents a relationship between a <see cref="Entities.Person"/> and it's associated <see cref="Entities.EmailAddress"/>
    /// </summary>
    public class PersonEmailAddress : BaseEntity
    {
        [IgnoreCodeCoverage]
        private PersonEmailAddress()
        {
        }
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="person">A <see cref="Entities.Person"/> object.</param>
        /// <param name="emailAddress">A <see cref="Entities.EmailAddress"/> object.</param>
        public PersonEmailAddress(Person person, EmailAddress emailAddress)
        {
            Person = person;
            EmailAddress = emailAddress;
        }
        /// <summary>
        /// The Id of the <see cref="Entities.Person"></see> associated with this entry.
        /// </summary>
        public int PersonId { get; private set; }
        /// <summary>
        /// Navigation property to the <see cref="Entities.Person"/> associated with this entry.
        /// </summary>
        public Person Person { get; private set; }
        /// <summary>
        /// The Id of the <see cref="Entities.EmailAddress"/> associated with this entry.
        /// </summary>
        public int EmailAddressId { get; private set; }
        /// <summary>
        /// Navigation property to the <see cref="Entities.EmailAddress"/> associated with this entry.
        /// </summary>
        public EmailAddress EmailAddress { get; private set; }
    }
}
