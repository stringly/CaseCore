using CaseCore.Common.Attributes;
using CaseCore.Domain.Common;
using CaseCore.Domain.Exceptions.Types;

namespace CaseCore.Domain.Types
{
    /// <summary>
    /// Entity class that represents an Offense Type.
    /// </summary>
    /// <remarks>
    /// Inherits from the <see cref="BaseEntity"/> class.
    /// </remarks>
    public class OffenseType : BaseEntity
    {
        [IgnoreCodeCoverage]
        private OffenseType() { }
        /// <summary>
        /// Creates a new Instance of the Class
        /// </summary>
        /// <param name="fullName">A string containing at least 2 but less than 50 characters representing the full name of the Offense Type.</param>
        /// <param name="Abbreviation">A string containing no more than 5 characters representing an abbreviation for the Offense Type.</param>
        public OffenseType(string fullName, string Abbreviation)
        {
            UpdateFullName(fullName);
            UpdateAbbreviation(Abbreviation);
        }
        private string _name;
        /// <summary>
        /// Returns the Full Name of the Offense Type.
        /// </summary>
        public string Name => _name;
        private string _abbreviation;
        /// <summary>
        /// Returns the Abbreviation for the Offense Type.
        /// </summary>
        public string Abbreviation => _abbreviation;
        /// <summary>
        /// Updates the Full Name of the Offense Type
        /// </summary>
        /// <param name="newFullName"></param>
        /// <exception cref="OffenseTypeArgumentException">Thrown when the newFullName parameter is empty/whitespace or less than 2 characters or greater than 50 characters.</exception>
        public void UpdateFullName(string newFullName)
        {
            if (string.IsNullOrWhiteSpace(newFullName))
            {
                throw new OffenseTypeArgumentException("Cannot update Offense Type Full Name: parameter cannot be null/empty string.", nameof(newFullName));
            }
            else if (newFullName.Length < 2 || newFullName.Length > 50)
            {
                throw new OffenseTypeArgumentException("Cannot update Offense Type Full Name: parameter must be more than 2 characters or fewer than 50 characters.", nameof(newFullName));
            }
            else
            {
                _name = newFullName;
            }
        }
        /// <summary>
        /// Updates the Abbreviation of the Offense Type
        /// </summary>
        /// <param name="newAbbreviation"></param>
        /// <exception cref="OffenseTypeArgumentException">Thrown when the newAbbreviation parameter is empty/whitespace or greater than 5 characters.</exception>
        public void UpdateAbbreviation(string newAbbreviation)
        {
            if (string.IsNullOrWhiteSpace(newAbbreviation))
            {
                throw new OffenseTypeArgumentException("Cannot update Offense Type Abbreviation: parameter cannot be null/empty string.", nameof(newAbbreviation));
            }
            else if (newAbbreviation.Length > 5)
            {
                throw new OffenseTypeArgumentException("Cannot update Offense Type Abbreviation: parameter cannot be more than 5 characters.", nameof(newAbbreviation));
            }
            else
            {
                _abbreviation = newAbbreviation;
            }
        }
    }
}
