using CaseCore.Domain.Common;
using CaseCore.Domain.Enums;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using System;
using System.Collections.Generic;

namespace CaseCore.Domain.Entities
{
    public class Person
    {
        private Person() { }
        public Person(int personTypeId, string honorific, string firstName, string middleName, string lastName, string suffix, string gender, string race, DateTime dob, string ssn)
        {

        }

        
        private Honorific _prefix;
        /// <summary>
        /// Person's prefix.
        /// </summary>
        private string Prefix => _prefix.GetDescription(); 
        /// <summary>
        /// Person's First/Given Name
        /// </summary>
        public string FirstName { get; private set; }
        /// <summary>
        /// Person's Middle Name
        /// </summary>
        public string MiddleName { get; private set; }
        /// <summary>
        /// Person's Last/Surname
        /// </summary>
        public string LastName { get; private set; }
        /// <summary>
        /// Person's suffix, i.e. "Jr.", "Sr.", etc.
        /// </summary>
        public string Suffix { get; private set; }
        /// <summary>
        /// Returns the person's full name in the format "First Last"
        /// </summary>
        public string FullName => FirstName + " " + LastName;
        /// <summary>
        /// Returns the person's full name in the format "Last, First"
        /// </summary>
        public string FullNameReverse => $"{LastName}, {FirstName}";
        public string FormalName => $"{Prefix.GetDescription()} {FirstName} {LastName} {(!string.IsNullOrEmpty(Suffix) ? $", {Suffix}" :" ")}";
        private int _personTypeId;
        /// <summary>
        /// The Id of the <see cref="PersonType"/> associated with the person.
        /// </summary>
        public virtual PersonType Type { get; private set; }

        private readonly List<PersonAddress> _addresses;
        /// <summary>
        /// Returns a readonly list of <see cref="PersonAddress"/> containing <see cref="Address"/> associated with this person.
        /// </summary>
        public IEnumerable<PersonAddress> Addresses => _addresses.AsReadOnly();
        private readonly List<PersonPhone> _phoneNumbers;
        /// <summary>
        /// Returns a readonly list of <see cref="PersonPhone"/> containing links to <see cref="PhoneNumber"/> associated with this person.
        /// </summary>
        public IEnumerable<PersonPhone> PhoneNumbers => _phoneNumbers.AsReadOnly();
        private Gender _gender;
        /// <summary>
        /// Returns a string of the Person's <see cref="Enums.Gender"/>
        /// </summary>
        public string Gender => _gender.GetDescription();
        /// <summary>
        /// Returns a string with the abbreviation for the person's gender.
        /// </summary>
        public string GenderAbbreviation => _gender.ToString();
        private Race _race;
        /// <summary>
        /// Returns a string containing Person's <see cref="Enums.Race"/>
        /// </summary>
        public string Race => _race.GetDescription();
        public string RaceAbbreviation => _race.ToString();
        private DateTime _dob;
        /// <summary>
        /// Returns a <see cref="DateTime"/> of the Person's Date of Birth
        /// </summary>
        public DateTime DOB => _dob;
        /// <summary>
        /// Returns the Person's date of birth as a MM/DD/YY string.
        /// </summary>
        public string DOBFormatted => _dob.ToShortDateString();
        private string _ssn;
        /// <summary>
        /// Returns a string containing the person's SSN.
        /// </summary>
        public string SSN => _ssn;
        /// <summary>
        /// Updates the PersonTypeId of the Person.
        /// </summary>
        /// <param name="newTypeId">An integer that is a valid Id for a <see cref="PersonType"/>.</param>
        /// <exception cref="PersonArgumentException">
        /// Thrown when the provided parameter is less than 1.
        /// </exception>
        public void UpdatePersonType(int newTypeId)
        {
            if (newTypeId < 1)
            {
                throw new PersonArgumentException("Cannot update Person Type: parameter is not a valid PersonType Id.", nameof(newTypeId));
            }
            _personTypeId = newTypeId;
        }
        /// <summary>
        /// Updates the Honorific of the Person.
        /// </summary>
        /// <param name="newHonorific">A string that can be converted to a <see cref="Honorific"/>.</param>
        /// <exception cref="PersonArgumentException">
        /// Thrown when the provided parameter cannot be converted to a <see cref="Honorific"/>.
        /// </exception>
        public void UpdateHonorific(string newHonorific)
        {
            try
            {
                _prefix = (Honorific)Enum.Parse(typeof(Honorific), newHonorific);
            }
            catch (ArgumentException)
            {
                throw new PersonArgumentException("Cannot update Person Honorific: parameter could not be converted to a valid Honorific.", nameof(newHonorific));
            }
        }
        /// <summary>
        /// Updates the Person's First Name
        /// </summary>
        /// <param name="newFirstName">A string containing the Person's first name.</param>
        /// <exception cref="PersonArgumentException">Thrown when the provided parameter is null/empty or longer than 50 characters.</exception>
        public void UpdateFirstName(string newFirstName)
        {
            if (string.IsNullOrWhiteSpace(newFirstName))
            {
                throw new PersonArgumentException("Cannot update Person's First Name: parameter cannot be null/whitespace.", nameof(newFirstName));
            }
            else if (newFirstName.Length > 50)
            {
                throw new PersonArgumentException("Cannot update Person's First Name: parameter cannot be longer than 50 characters.", nameof(newFirstName));
            }
            FirstName = newFirstName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newAddress"></param>
        public void AddAddress(Address newAddress)
        {
            _addresses.Add(new PersonAddress(newAddress));
        }
        /// <summary>
        /// Adds a phone number to the Person's phone number collection.
        /// </summary>
        /// <param name="newNumber">The <see cref="Entities.PhoneNumber"/> to add to the collection.</param>
        public void AddPhoneNumber(PhoneNumber newNumber)
        {
            _phoneNumbers.Add(new PersonPhone(newNumber));
        }

    }
}
