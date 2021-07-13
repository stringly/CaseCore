using CaseCore.Domain.Common;
using CaseCore.Domain.Exceptions.Entities;

namespace CaseCore.Domain.Entities
{
    public class EmailAddress : BaseEntity
    {
        private EmailAddress() { }
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="address">A string containing an email address. Must be 50 characters or fewer.</param>
        public EmailAddress(string address)
        {
            UpdateEmail(address);
        }
        private string _emailAddress;
        public string Address => _emailAddress;
        /// <summary>
        /// Updates the email address.
        /// </summary>
        /// <param name="newEmail">A string containing an email address. Must be 50 characters or fewer.</param>
        /// <exception cref="EmailAddressArgumentException">
        /// Thrown when the provided parameter is null, whitespace, or contains more than 50 characters.
        /// </exception>
        public void UpdateEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
            {
                throw new EmailAddressArgumentException("Cannot update Email Address: parameter cannot be null or whitespace.", nameof(newEmail));
            }
            else if (newEmail.Length > 50)
            {
                throw new EmailAddressArgumentException("Cannot update Email Address: parameter must be 50 characters or fewer.", nameof(newEmail));
            }
            _emailAddress = newEmail;
        }
    }
}
