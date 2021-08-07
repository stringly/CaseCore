using CaseCore.Domain.Common;
using CaseCore.Domain.Enums;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CaseCore.Domain.Entities

{
    public class Person : AuditableEntity
    {
        private Person() { }
        public Person(PersonType type, string honorific, string firstName, string middleName, string lastName, string suffix, string gender, string race, DateTime dob, string ssn)
        {
            UpdatePersonType(type);
            UpdateHonorific(honorific);
            UpdateFirstName(firstName);
            UpdateMiddleName(middleName);
            UpdateLastName(lastName);
            UpdateSuffix(suffix);
            UpdateGender(gender);
            UpdateRace(race);
            UpdateDOB(dob);
            UpdateSSN(ssn);
            _addresses = new List<PersonAddress>();
            _phoneNumbers = new List<PersonPhoneNumber>();
            _emailAddresses = new List<PersonEmailAddress>();
        }

        
        private Honorific _prefix;
        /// <summary>
        /// Person's prefix.
        /// </summary>
        public Honorific Prefix => _prefix;
        /// <summary>
        /// Returns the Prefix title as a string.
        /// </summary>
        public string TitleOfCourtesy => _prefix.GetDescription(); 
        private string _firstName;        
        /// <summary>
        /// Person's First/Given Name
        /// </summary>        
        public string FirstName => _firstName;
        private string _middleName;
        /// <summary>
        /// Person's Middle Name
        /// </summary>
        public string MiddleName => _middleName;
        public string _lastName;
        /// <summary>
        /// Person's Last/Surname
        /// </summary>
        public string LastName => _lastName;
        private string _suffix;
        /// <summary>
        /// Person's suffix, i.e. "Jr.", "Sr.", etc.
        /// </summary>
        public string Suffix => _suffix;
        /// <summary>
        /// Returns the person's full name in the format "First Last"
        /// </summary>
        public string FullName => _firstName + " " + _lastName;
        /// <summary>
        /// Returns the person's full name in the format "Last, First"
        /// </summary>
        public string FullNameReverse => $"{_lastName}, {_firstName}";
        public string FormalName => $"{TitleOfCourtesy} {_firstName} {_lastName}{(!string.IsNullOrEmpty(_suffix) ? $", {_suffix}" :"")}";
        /// <summary>
        /// The Id of the <see cref="Types.PersonType"/> associated with the person.
        /// </summary>
        public int PersonTypeId {get; private set; }
        /// <summary>
        /// Navigation property for the <see cref="Types.PersonType"/> associated with the Person.
        /// </summary>
        public PersonType PersonType { get; private set; }
        private readonly List<PersonAddress> _addresses;
        /// <summary>
        /// Returns a readonly collection of <see cref="PersonAddress"/> associated with the person.
        /// </summary>
        public virtual IEnumerable<PersonAddress> Addresses => _addresses.AsReadOnly();
        /// <summary>
        /// Returns a readonly list of <see cref="Entities.PersonPhoneNumber"/> associated with this person.
        /// </summary>
        private readonly List<PersonPhoneNumber> _phoneNumbers;
        /// <summary>
        /// Returns a readonly list of <see cref="Entities.PersonPhoneNumber"/> associated with this person.
        /// </summary>
        public virtual IEnumerable<PersonPhoneNumber> PhoneNumbers => _phoneNumbers.AsReadOnly();
        /// <summary>
        /// Returns a readonly list of <see cref="PersonEmailAddress"/> associated with this person.
        /// </summary>
        private readonly List<PersonEmailAddress> _emailAddresses;
        /// <summary>
        /// Returns a readonlyt list of <see cref="PersonEmailAddress"/> associated with this person.
        /// </summary>
        public virtual IEnumerable<PersonEmailAddress> EmailAddresses => _emailAddresses.AsReadOnly();
        private Gender _gender;
        /// <summary>
        /// Returns a string of the Person's <see cref="Enums.Gender"/>
        /// </summary>
        public Gender Gender => _gender;
        /// <summary>
        /// Returns the Gender enum as a string.
        /// </summary>
        public string GenderName => _gender.GetDescription();
        /// <summary>
        /// Returns a string with the abbreviation for the person's gender.
        /// </summary>
        public string GenderAbbreviation => _gender.ToString();
        private Race _race;
        /// <summary>
        /// Returns the Race as a <see cref="Race"/> enum.
        /// </summary>
        public Race Race => _race;
        /// <summary>
        /// Returns a string containing Person's <see cref="Enums.Race"/>
        /// </summary>        
        public string RaceName => _race.GetDescription();
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
        /// Updates the Honorific of the Person.
        /// </summary>
        /// <remarks>
        /// Valid values for Honorific are:
        /// <list type="bullet">
        /// <item>'Mr' for "Mr."/Caucasian</item>
        /// <item>'Ms' for "Ms."</item>
        /// <item>'Mrs' for "Mrs."</item>
        /// <item>'Mx' for "Mx."</item>        
        /// </list>
        /// </remarks>
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
            _firstName = newFirstName;
        }
        /// <summary>
        /// Updates the Person's Last Name
        /// </summary>
        /// <param name="newMiddleName">A string containing the Person's middle name.</param>
        /// <exception cref="PersonArgumentException">Thrown when the provided parameter is null/empty or longer than 50 characters.</exception>
        public void UpdateMiddleName(string newMiddleName)
        {
            if (string.IsNullOrWhiteSpace(newMiddleName))
            {
                throw new PersonArgumentException("Cannot update Person's Middle Name: parameter cannot be null/whitespace.", nameof(newMiddleName));
            }
            else if (newMiddleName.Length > 50)
            {
                throw new PersonArgumentException("Cannot update Person's First Name: parameter cannot be longer than 50 characters.", nameof(newMiddleName));
            }
            _middleName = newMiddleName;
        }
        /// <summary>
        /// Updates the Person's Last Name
        /// </summary>
        /// <param name="newLastName">A string containing the Person's Last name.</param>
        /// <exception cref="PersonArgumentException">Thrown when the provided parameter is null/empty or longer than 50 characters.</exception>
        public void UpdateLastName(string newLastName)
        {
            if (string.IsNullOrWhiteSpace(newLastName))
            {
                throw new PersonArgumentException("Cannot update Person's Last Name: parameter cannot be null/whitespace.", nameof(newLastName));
            }
            else if (newLastName.Length > 50)
            {
                throw new PersonArgumentException("Cannot update Person's Last Name: parameter cannot be longer than 50 characters.", nameof(newLastName));
            }
            _lastName = newLastName;
        }
        /// <summary>
        /// Updates the Person's Suffix.
        /// </summary>
        /// <param name="newSuffix">A string containing the new suffix.</param>
        /// <exception cref="PersonArgumentException">Thrown if the parameter provided is more than 10 characters in length.</exception>
        public void UpdateSuffix(string newSuffix)
        {
            if (newSuffix.Length > 10)
            {
                throw new PersonArgumentException("Cannot update Person's Suffix: suffix must be 10 characters or fewer.", nameof(newSuffix));
            }
            _suffix = newSuffix;
        }
        /// <summary>
        /// Updates the <see cref="Types.PersonType"/>.
        /// </summary>
        /// <param name="newTypeId">An integer that is a valid Id for a <see cref="Types.PersonType"/>.</param>
        public void UpdatePersonType(PersonType newType)
        {
            PersonType = newType;
        }
        /// <summary>
        /// Updates the Person's Gender.
        /// </summary>
        /// Valid values for gender are:
        /// <list type="bullet">
        /// <item>'M' for male</item>
        /// <item>'F' for female</item>
        /// <item>'N' for Non-binary</item>        
        /// <item?'O' for Other/Not Listed</item>
        /// </list>
        /// </remarks>
        /// <param name="newGender">A string containing the Person's gender.</param>
        /// <exception cref="PersonArgumentException">Thrown if the parameter provided cannot be converted to a <see cref="Enums.Gender"/></exception>
        public void UpdateGender(string newGender)
        {
            try
            {
                _gender = (Gender)Enum.Parse(typeof(Gender), newGender);
            }
            catch (ArgumentException)
            {
                throw new PersonArgumentException("Cannot update Person's Gender: parameter could not be converted to a Gender Enumeration.", nameof(newGender));
            }
        }
        /// <summary>
        /// Updates the Person's Race
        /// </summary>
        /// <remarks>
        /// Valid values for Race are:
        /// <list type="bullet">
        /// <item>'W' for White/Caucasian</item>
        /// <item>'B' for Black</item>
        /// <item>'H' for Hispanic</item>
        /// <item>'A' for Asian/Pacific Islander</item>
        /// <item?'O' for Other/Not Listed</item>
        /// </list>
        /// </remarks>
        /// <param name="newRace">A string containing the new Race.</param>
        /// <exception cref="PersonArgumentException">Thrown when the provided </exception>
        public void UpdateRace(string newRace)
        {
            try
            {
                _race = (Race)Enum.Parse(typeof(Race), newRace);
            }
            catch (ArgumentException)
            {
                throw new PersonArgumentException("Cannot update Person's Race: parameter could not be converted to a Race Enumeration.", nameof(newRace));
            }
        }
        /// <summary>
        /// Updates the Person's Date of Birth.
        /// </summary>
        /// <param name="newDOB">The Person's Date of Birth.</param>
        /// <exception cref="PersonArgumentException">Thrown if the parameter provided is equal to the DateTime object's minimum value.</exception>
        public void UpdateDOB(DateTime newDOB)
        {
            if (newDOB == DateTime.MinValue)
            {
                throw new PersonArgumentException("Cannot update person's Date of Birth: parameter cannot be DateTime.MinValue.", nameof(newDOB));
            }
            _dob = newDOB;
        }
        /// <summary>
        /// Updates the Person's Social Security Number.
        /// </summary>
        /// <param name="newSSN">A string containing a valid SSN.</param>
        /// <exception cref="PersonArgumentException">Thrown when the provided parameter is not a valid SSN.</exception>
        public void UpdateSSN(string newSSN)
        {
            if (!IsValidSSN(newSSN))
            {
                throw new PersonArgumentException("Cannot update Person's Social Security Number: parameter is not a valid SSN", nameof(newSSN));
            }
            _ssn = newSSN;
        }
        /// <summary>
        /// Adds a <see cref="PhoneNumber"/> to the Person's <see cref="PersonPhoneNumber"/> collection.
        /// </summary>
        /// <param name="phoneNumber">The <see cref="PhoneNumber"/> to add.</param>
        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            _phoneNumbers.Add(new PersonPhoneNumber(this, phoneNumber));
        }
        public void RemovePhoneNumber(PhoneNumber phoneNumber)
        {
            PersonPhoneNumber toRemove = _phoneNumbers?.Find(x => x.PhoneNumber == phoneNumber);
            if (phoneNumber == null)
            {
                throw new PersonArgumentException("Cannot remove phone number from person: phone number not found in Phone Number collection.", nameof(phoneNumber));
            }
            _phoneNumbers.Remove(toRemove);
        }

        private bool IsValidSSN(string ssn)
        {
            var _withDashRegEx = @"^(?!219-09-9999|078-05-1120)(?!666|000|9\d{2})\d{3}-(?!00)\d{2}-(?!0{4})\d{4}$";
            var _withoutDashRegEx = @"^(?!219099999|078051120)(?!666|000|9\d{2})\d{3}(?!00)\d{2}(?!0{4})\d{4}$";
            var validSSN = false;
            if ((Regex.Match(ssn, _withDashRegEx).Success) || (Regex.Match(ssn, _withoutDashRegEx).Success))
            {
                validSSN = true;
            }
            return validSSN;
        }
        /// <summary>
        /// Adds an address to the Person's Address collection.
        /// </summary>
        /// <param name="address">A <see cref="Address"/> object.</param>
        public void AddAddress(Address address)
        {
            _addresses.Add(new PersonAddress(this, address));
        }
        /// <summary>
        /// Removes an address from the Person's Address collection.
        /// </summary>
        /// <param name="address"></param>
        /// <exception cref="PersonArgumentException">Thrown when the provided address parameter is not found in the Person's address collection.</exception>
        public void RemoveAddress(Address address)
        {
            PersonAddress toRemove = _addresses?.Find(x => x.Address == address);
            if (toRemove == null)
            {
                throw new PersonArgumentException("Cannot remove Address from Person: Address not found in Addresses Collection.", nameof(address));
            }
            _addresses.Remove(toRemove);
        }
        /// <summary>
        /// Adds an email address to the Person's Email Address collection.
        /// </summary>
        /// <param name="emailAddress">A <see cref="EmailAddress"/> object.</param>
        public void AddEmailAddress(EmailAddress emailAddress)
        {
            _emailAddresses.Add(new PersonEmailAddress(this, emailAddress));
        }
        /// <summary>
        /// Removes an email address from the Person's Email Address collection.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <exception cref="PersonArgumentException">Thrown when the provided email address parameter is not found in the Person's address collection.</exception>
        public void RemoveEmailAddress(EmailAddress emailAddress)
        {
            PersonEmailAddress toRemove = _emailAddresses?.Find(x => x.EmailAddress == emailAddress);
            if (toRemove == null)
            {
                throw new PersonArgumentException("Cannot remove Email Address from Person: Email Address not found in Email Addresses Collection.", nameof(emailAddress));
            }
            _emailAddresses.Remove(toRemove);
        }
    }
}
