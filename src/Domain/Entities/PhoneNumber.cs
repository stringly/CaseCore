using CaseCore.Domain.Common;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Class that represents a <see cref="Entities.Person"/> and it's associated <see cref="Entities.PhoneNumber"/>
    /// </summary>
    public class PhoneNumber : BaseEntity
    {
        private PhoneNumber() { }
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="number">A <see cref="Entities.PhoneNumber"/></param>
        public PhoneNumber(string number, int phoneTypeId)
        {
            UpdateNumber(number);
            UpdateType(phoneTypeId);
        }
        private string _number;
        /// <summary>
        /// Returns a string containing the phone number digits with no punctucation.
        /// </summary>
        public string Number => _number;
        public int PhoneNumberTypeId { get; private set; }
        /// <summary>
        /// The <see cref="PhoneType"/> of the number.
        /// </summary>
        public PhoneNumberType PhoneNumberType { get; private set; }
        /// <summary>
        /// Returns the phone number formatted as (123) 456-7890. 
        /// </summary>
        /// <remarks>
        /// This will only format the number if it is 10 digits. More or less will return the unformatted number.
        /// </remarks>
        public string PhoneNumberFormatted {
            get {
                if (_number.Length == 10)
                {
                    return $"({_number.Substring(0, 3)}) {_number.Substring(3, 3)}-{_number.Substring(6, 4)}";
                }
                else
                {
                    return _number;
                }
            }
        }
        public void UpdateNumber(string newNumber)
        {
            string sanitized = newNumber.RemoveNonNumericCharacters();
            if (sanitized.Length != 10)
            {
                throw new PhoneNumberArgumentException("Cannot Update Phone Number: provided parameter does not contain 10 numeric digits.", nameof(newNumber));
            }
            _number = sanitized;
        }
        public void UpdateType(int newTypeId)
        {
            if (newTypeId < 1)
            {
                throw new PhoneNumberArgumentException("Cannot Update Phone Number Type: provided parameter is not a valid type.", nameof(newTypeId));
            }
            PhoneNumberTypeId = newTypeId;
        }
    }
}
