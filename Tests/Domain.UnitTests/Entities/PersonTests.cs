using CaseCore.Domain.Entities;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using System;
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
        public void Should_Throw_PersonArgumentException_For_Invalid_Honorific()
        {

        }
        // TODO: Add testing for collections: Phone, Email, Address

    }
}
