using CaseCore.Common.Attributes;
using CaseCore.Domain.Common;
using CaseCore.Domain.Exceptions.Types;

namespace CaseCore.Domain.Types
{
    /// <summary>
    /// Represents a Type of Address
    /// </summary>
    public class AddressType : BaseEntity
    {
        [IgnoreCodeCoverage]
        private AddressType() { }
        /// <summary>
        /// Creates a new Instance of the Class
        /// </summary>
        /// <param name="fullName">A string containing at least 2 but less than 50 characters representing the full name of the Address Type.</param>
        /// <param name="Abbreviation">A string containing no more than 5 characters representing an abbreviation for the Address Type.</param>
        public AddressType(string fullName, string Abbreviation)
        {
            UpdateFullName(fullName);
            UpdateAbbreviation(Abbreviation);            
        }
        private string _name;
        /// <summary>
        /// Returns the Full Name of the Address Type.
        /// </summary>
        public string Name => _name;
        private string _abbreviation;
        /// <summary>
        /// Returns the Abbreviation for the address.
        /// </summary>
        public string Abbreviation => _abbreviation;
        /// <summary>
        /// Updates the Full Name of the Address Type
        /// </summary>
        /// <param name="newFullName"></param>
        /// <exception cref="AddressTypeArgumentException">Thrown when the newFullName parameter is empty/whitespace or less than 2 characters or greater than 50 characters.</exception>
        public void UpdateFullName(string newFullName)
        {
            if (string.IsNullOrWhiteSpace(newFullName))
            {
                throw new AddressTypeArgumentException("Cannot update Address Type Full Name: parameter cannot be null/empty string.", nameof(newFullName));
            }
            else if (newFullName.Length < 2 || newFullName.Length > 50)
            {
                throw new AddressTypeArgumentException("Cannot update Address Type Full Name: parameter must be more than 2 characters or fewer than 50 characters.", nameof(newFullName));
            }
            else
            {
                _name = newFullName;
            }            
        }
        /// <summary>
        /// Updates the Abbreviation of the Address Type
        /// </summary>
        /// <param name="newAbbreviation"></param>
        /// <exception cref="AddressTypeArgumentException">Thrown when the newAbbreviation parameter is empty/whitespace or greater than 5 characters.</exception>
        public void UpdateAbbreviation(string newAbbreviation)
        {
            if (string.IsNullOrWhiteSpace(newAbbreviation))
            {
                throw new AddressTypeArgumentException("Cannot update Address Type Abbreviation: parameter cannot be null/empty string.", nameof(newAbbreviation));
            }
            else if (newAbbreviation.Length > 5)
            {
                throw new AddressTypeArgumentException("Cannot update Address Type Abbreviation: parameter cannot be more than 5 characters.", nameof(newAbbreviation));
            }
            else
            {
                _abbreviation = newAbbreviation;
            }
        }
        
    }

}
