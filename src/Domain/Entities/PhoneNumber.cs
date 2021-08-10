using CaseCore.Domain.Common;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Class that represents a PhoneNumber
    /// </summary>
    public class PhoneNumber : BaseEntity
    {
        private PhoneNumber() { }
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="number">A <see cref="Entities.PhoneNumber"/></param>
        /// <param name="type">A <see cref="Types.PhoneNumberType"/></param>
        public PhoneNumber(string number, PhoneNumberType type)
        {
            UpdateNumber(number);
            UpdateType(type);
        }
        private string _number;
        /// <summary>
        /// Returns a string containing the phone number digits with no punctucation.
        /// </summary>
        public string Number => _number;
        /// <summary>
        /// The Id of the <see cref="Types.PhoneNumberType"/>
        /// </summary>
        public int PhoneNumberTypeId { get; private set; }
        /// <summary>
        /// The <see cref="Types.PhoneNumberType"/> of the number.
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
        /// <summary>
        /// Updates the phone number of the object.
        /// </summary>
        /// <param name="newNumber">A string containing a new phone number</param>
        /// <exception cref="PhoneNumberArgumentException">Thrown when the provided parameter contains non-numeric characters or is more than 10 characters in length.</exception>
        public void UpdateNumber(string newNumber)
        {
            string sanitized = newNumber.RemoveNonNumericCharacters();
            if (sanitized.Length != 10)
            {
                throw new PhoneNumberArgumentException("Cannot Update Phone Number: provided parameter does not contain 10 numeric digits.", nameof(newNumber));
            }
            _number = sanitized;
        }
        /// <summary>
        /// Updates the <see cref="Types.PhoneNumberType"/> of the phone number.
        /// </summary>
        /// <param name="newType">A <see cref="Types.PhoneNumberType"/></param>
        public void UpdateType(PhoneNumberType newType)
        {
            PhoneNumberType = newType;
        }
    }
}
