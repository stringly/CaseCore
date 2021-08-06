using CaseCore.Domain.Common;
using CaseCore.Domain.Exceptions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseCore.Domain.Entities
{
    public class Case : AuditableEntity
    {
        private Case()
        {

        }
        public Case(string caseNumber) 
        {
            UpdateCaseNumber(caseNumber);    
            _persons = new List<Person>();
            _addresses = new List<CaseAddress>();
        }

        private string _caseNumber;
        public string CaseNumber => _caseNumber;

        private readonly List<Person> _persons;
        /// <summary>
        /// Returns a readonly list of <see cref="Person"/> entities associated with this case.
        /// </summary>
        public virtual IEnumerable<Person> Persons => _persons.AsReadOnly();
        private readonly List<CaseAddress> _addresses;
        public virtual IEnumerable<CaseAddress> Addresses => _addresses.AsReadOnly();

        public void UpdateCaseNumber(string newCaseNumber)
        {
            if (string.IsNullOrWhiteSpace(newCaseNumber))
            {
                throw new CaseArgumentException("Cannot update Case Number: parameter cannot be null or whitespace.", nameof(newCaseNumber));
            }
            _caseNumber = newCaseNumber;
        }
        /// <summary>
        /// Adds an address to the Case's Address collection.
        /// </summary>
        /// <param name="address">A <see cref="Address"/> object.</param>
        public void AddAddress(Address address)
        {
            _addresses.Add(new CaseAddress(this, address));
        }
        /// <summary>
        /// Removes an address from the Case's Address collection.
        /// </summary>
        /// <param name="address"></param>
        /// <exception cref="CaseArgumentException">Thrown when the provided address parameter is not found in the Case's address collection.</exception>
        public void RemoveAddress(Address address)
        {
            CaseAddress toRemove = _addresses?.Find(x => x.Address == address);
            if (toRemove == null)
            {
                throw new CaseArgumentException("Cannot remove Address from Case: Address not found in Addresses Collection.", nameof(address));
            }
            _addresses.Remove(toRemove);
        }
    }
}
