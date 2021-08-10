using CaseCore.Domain.Common;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Entity class that represents a relationship between a <see cref="Entities.Case"></see> and its associated <see cref="Entities.Person"/> records.
    /// </summary>
    public class CasePerson : BaseEntity
    {
        private CasePerson() { }
        /// <summary>
        /// Creates a new Instance of the Class.
        /// </summary>
        /// <param name="_case">A <see cref="Entities.Case"/> object.</param>
        /// <param name="person">A <see cref="Entities.Person"/> object.</param>
        public CasePerson(Case _case, Person person)
        {
            Case = _case;
            Person = person;
        }
        /// <summary>
        /// The integer Id of the <see cref="Entities.Case"/> associated with the record.
        /// </summary>
        public int CaseId { get; private set; }
        /// <summary>
        /// Navigation property to the <see cref="Entities.Case"/> associated with the record.
        /// </summary>
        public virtual Case Case { get; private set; }
        /// <summary>
        /// The integer Id of the <see cref="Entities.Person"/> associated with the record.
        /// </summary>
        public int PersonId { get; private set; }
        /// <summary>
        /// Navigation property to the <see cref="Entities.Person"/> associated with the record.
        /// </summary>
        public virtual Person Person { get; private set; }
    }
}
