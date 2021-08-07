using CaseCore.Domain.Entities;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using System;
using System.Linq;
using Xunit;

namespace CaseCore.Domain.UnitTests.Entities
{
    public class PersonTests
    {
        /// <summary>
        /// Factory Method that creates a default Person for Test Methods.
        /// </summary>
        /// <returns>A <see cref="Person"/> object with default values.</returns>
        private Person CreatePerson()
        {
            // Arrange
            PersonType testType = new PersonType("Test", "X");
            string prefix = "Mr";
            string firstName = "John";
            string middleName = "Que";
            string lastName = "Public";
            string suffix = "Jr.";
            string gender = "M";
            string race = "W";
            DateTime dob = new DateTime(1980, 1, 1);
            string ssn = "123-45-6789";

            return new Person(testType, prefix, firstName, middleName, lastName, suffix, gender, race, dob, ssn);
        }
        [Fact]
        public void Given_Valid_Values_Person_Is_Valid()
        {
            // Act
            Person newPerson = CreatePerson();

            // Assert
            Assert.Equal("John", newPerson.FirstName);
            Assert.Equal("Mr. John Public, Jr.", newPerson.FormalName);
            Assert.Equal(new DateTime(1980, 1, 1), newPerson.DOB);
            Assert.Equal("W", newPerson.RaceAbbreviation);
            Assert.Equal("M", newPerson.GenderAbbreviation);
        }
        [Fact]
        public void Can_Update_PersonType()
        {
            // Arrange
            Person newPerson = CreatePerson();
            PersonType newPersonType = new PersonType("Suspect", "S");

            // Act
            newPerson.UpdatePersonType(newPersonType);

            // Assert
            Assert.Equal(newPersonType, newPerson.PersonType);
        }
        [Fact]
        public void Can_Update_Honorific()
        {
            // Arrange
            string newHonorific = "Mrs";
            Person newPerson = CreatePerson();

            // Act
            newPerson.UpdateHonorific(newHonorific);

            // Assert
            Assert.Equal("Mrs.", newPerson.TitleOfCourtesy);
            
        }
        [Fact]
        public void Can_Update_FirstName()
        {
            // Arrange
            Person newPerson = CreatePerson();
            string newFirstName = "Bob";

            // Act
            newPerson.UpdateFirstName(newFirstName);

            // Assert
            Assert.Equal("Bob", newPerson.FirstName);
        }

        [Fact]
        public void Can_Update_MiddleName()
        {
            // Arrange
            Person newPerson = CreatePerson();
            string newMiddleName = "Test";

            // Act
            newPerson.UpdateMiddleName(newMiddleName);

            // Assert
            Assert.Equal("Test", newPerson.MiddleName);
        }
        [Fact]
        public void Can_Update_LastName()
        {
            // Arrange
            Person newPerson = CreatePerson();
            string newLastName = "Test";

            // Act
            newPerson.UpdateLastName(newLastName);

            // Assert
            Assert.Equal("Test", newPerson.LastName);
        }
        [Fact]
        public void Can_Update_Suffix()
        {
            // Arrange
            Person newPerson = CreatePerson();
            string newSuffix = "Ms";

            // Act
            newPerson.UpdateSuffix(newSuffix);
            
            // Assert
            Assert.Equal("Ms", newPerson.Suffix.ToString());

        }
        [Fact]
        public void Can_Update_Gender()
        {
            // Arrange
            Person newPerson = CreatePerson();
            string newGender = "F";

            // Act
            newPerson.UpdateGender(newGender);

            // Assert
            Assert.Equal(newGender, newPerson.Gender.ToString());

        }
        [Fact]
        public void Can_Update_Race()
        {
            // Arrange
            Person newPerson = CreatePerson();
            string newRace = "O";

            // Act
            newPerson.UpdateRace(newRace);

            // Assert
            Assert.Equal(newRace, newPerson.Race.ToString());
        }
        [Fact]
        public void Can_Update_DOB()
        {
            // Arrange
            Person newPerson = CreatePerson();
            DateTime newDOB = new DateTime(1990, 1, 1);

            // Act
            newPerson.UpdateDOB(newDOB);
            
            // Assert
            Assert.Equal(newDOB, newPerson.DOB);
        }
        [Fact]
        public void Can_Update_SSN()
        {
            // Arrange
            Person newPerson = CreatePerson();
            string newSSN = "111-22-3333";

            // Act
            newPerson.UpdateSSN(newSSN);

            // Assert
            Assert.Equal(newSSN, newPerson.SSN);
        }
        [Fact]
        public void Can_Add_Address()
        {
            // Arrange
            Person newPerson = CreatePerson();
            Address newAddress = new Address(new AddressType("Home", "H"), "999 Main St.", "", "HomeTown", "AK", "12345");

            // Act
            newPerson.AddAddress(newAddress);

            // Assert
            Assert.Single(newPerson.Addresses);
            Assert.Equal(newPerson.Addresses.First().Address, newAddress);
        }
        [Fact]
        public void Can_Remove_Address()
        {
            // Arrange
            Person newPerson = CreatePerson();
            Address newAddress = new Address(new AddressType("Home", "H"), "999 Main St.", "", "HomeTown", "AK", "12345");
            newPerson.AddAddress(newAddress);
            var initialAddressCount = newPerson.Addresses.Count();

            // Act
            newPerson.RemoveAddress(newAddress);

            // Assert
            Assert.Equal(1, initialAddressCount);
            Assert.Empty(newPerson.Addresses);
        }
        [Fact]
        public void Should_Throw_PersonArgumentException_For_Invalid_Honorific()
        {

        }
        // TODO: Add testing for collections: Phone, Email, Address

    }
}
