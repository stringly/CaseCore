using CaseCore.Domain.Common;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Junction class that creates a link between a <see cref="Entities.Person"/> and it's associated <see cref="Entities.PhoneNumber"/>
    /// </summary>
    public class PersonPhone : BaseEntity
    {
        private PersonPhone() { }
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="number">A <see cref="Entities.PhoneNumber"/></param>
        public PersonPhone(PhoneNumber number)
        {
            PhoneNumber = number;
        }
        /// <summary>
        /// The Id of the <see cref="Entities.Person"/> associated with the record.
        /// </summary>
        public int PersonId { get; set; }
        /// <summary>
        /// Navigation property to the <see cref="Entities.Person"/> associated with the record.
        /// </summary>
        public virtual Person Person { get; set; }
        /// <summary>
        /// The Id of the <see cref="Entities.PhoneNumber"/> associated with the record.
        /// </summary>
        public int PhoneNumberId { get; set; }
        /// <summary>
        /// Navigation property to the <see cref="Entities.PhoneNumber" /> associated with the record.
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }
    }
}
