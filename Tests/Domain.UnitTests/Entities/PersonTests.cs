using CaseCore.Domain.Common;
using CaseCore.Domain.Entities;
using CaseCore.Domain.Enums;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using CaseCore.Domain.UnitTests.Common;
using System;
using System.Linq;
using Xunit;

namespace CaseCore.Domain.UnitTests.Entities
{
    public class PersonTests : EntityTestBase
    {
        [Fact]
        public void Given_Valid_Values_Person_Is_Valid()
        {
            // Act
            Person newPerson = _factory.CreatePerson();

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
            Person newPerson = _factory.CreatePerson();
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
            Person newPerson = _factory.CreatePerson();

            // Act
            newPerson.UpdateHonorific(newHonorific);

            // Assert
            Assert.Equal("Mrs.", newPerson.TitleOfCourtesy);
            Assert.Equal(Honorific.Mrs, newPerson.Prefix);
            
        }
        [Fact]
        public void Can_Update_FirstName()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
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
            Person newPerson = _factory.CreatePerson();
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
            Person newPerson = _factory.CreatePerson();
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
            Person newPerson = _factory.CreatePerson();
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
            Person newPerson = _factory.CreatePerson();
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
            Person newPerson = _factory.CreatePerson();
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
            Person newPerson = _factory.CreatePerson();
            DateTime newDOB = new DateTime(1990, 1, 1);

            // Act
            newPerson.UpdateDOB(newDOB);
            
            // Assert
            Assert.Equal(newDOB, newPerson.DOB);
        }
        [Fact]
        public void Can_Update_Height()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            int newHeight = 78;

            // Act
            newPerson.UpdateHeight(newHeight);

            // Assert
            Assert.Equal("6'6\"", newPerson.Height);
            Assert.Equal(78, newPerson.HeightInInches);
        }
        [Fact]
        public void Can_Update_SSN()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
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
            Person newPerson = _factory.CreatePerson();
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
            Person newPerson = _factory.CreatePerson();
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
        public void Can_Add_PhoneNumber()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            PhoneNumber newNumber = new PhoneNumber("1234567890", new PhoneNumberType("Test", "X"));

            // Act
            newPerson.AddPhoneNumber(newNumber);

            // Assert
            Assert.Equal(newNumber, newPerson.PhoneNumbers.First().PhoneNumber);
            Assert.Single(newPerson.PhoneNumbers);
        }
        [Fact]
        public void Can_Remove_PhoneNumber()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            PhoneNumber newNumber = new PhoneNumber("1234567890", new PhoneNumberType("Test", "X"));
            newPerson.AddPhoneNumber(newNumber);
            int phoneCount = newPerson.PhoneNumbers.Count();

            // Act
            newPerson.RemovePhoneNumber(newNumber);

            // Assert
            Assert.Empty(newPerson.PhoneNumbers);
            Assert.Equal(1, phoneCount);
        }
        [Fact]
        public void Can_Add_Email()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            EmailAddress newEmail = new EmailAddress("test@test.com");

            // Act
            newPerson.AddEmailAddress(newEmail);

            // Assert
            Assert.Single(newPerson.EmailAddresses);
            Assert.Equal(newEmail, newPerson.EmailAddresses.First().EmailAddress);

        }
        [Fact]
        public void Can_Remove_Email()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            EmailAddress newEmail = new EmailAddress("test@test.com");
            newPerson.AddEmailAddress(newEmail);
            int emailCount = newPerson.EmailAddresses.Count();

            // Act
            newPerson.RemoveEmailAddress(newEmail);

            // Assert
            Assert.Equal(1, emailCount);
            Assert.Empty(newPerson.EmailAddresses);

        }
        [Fact]
        public void DOBFormatted_Returns_Proper_Format()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();

            // Act
            string DOBFormatted = newPerson.DOBFormatted;

            // Assert
            Assert.Equal(DOBFormatted, newPerson.DOB.ToShortDateString());
        }
        [Fact]
        public void GenderName_Returns_Gender_Name()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();

            // Act
            string genderName = newPerson.GenderName;

            // Assert
            Assert.Equal(genderName, newPerson.Gender.GetDescription());
        }
        [Fact]
        public void RaceName_Returns_Race_Name()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();

            // Act
            string raceName = newPerson.RaceName;

            // Assert
            Assert.Equal(raceName, newPerson.Race.GetDescription());
        }
        [Fact]
        public void FullName_Returns_Proper_Format()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();

            // Act
            string fullName = newPerson.FullName;

            // Assert
            Assert.Equal("John Public", fullName);
        }
        [Fact]
        public void FullNameReverse_Returns_Proper_Format()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();

            // Act/Assert
            Assert.Equal("Public, John", newPerson.FullNameReverse);
            
        }
        [Fact]
        public void Should_Throw_PersonArgumentException_For_Invalid_Honorific()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            string newHonorific = "XX";

            // Act/Assert
            Assert.Throws<PersonArgumentException>(() => newPerson.UpdateHonorific(newHonorific));
        }
        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")]
        public void Should_Throw_PersonArgumentException_For_Invalid_First_Name(string value)
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            string newFirstName = value;

            // Act/Assert
            Assert.Throws<PersonArgumentException>(() => newPerson.UpdateFirstName(newFirstName));

        }
        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")]
        public void Should_Throw_PersonArgumentException_For_Invalid_Middle_Name(string value)
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            string newMiddleName = value;

            // Act/Assert
            Assert.Throws<PersonArgumentException>(() => newPerson.UpdateMiddleName(newMiddleName));
        }
        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")]
        public void Should_Throw_PersonArgumentException_For_Invalid_Last_Name(string value)
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            string newLastName = value;

            // Act/Assert
            Assert.Throws<PersonArgumentException>(() => newPerson.UpdateLastName(newLastName));
        }
        [Theory]
        [InlineData("XXXXXXXXXXX")]
        public void Should_Throw_PersonArgumentException_For_Invalid_Suffix(string value)
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            string newSuffix = value;

            // Act/Assert
            Assert.Throws<PersonArgumentException>(() => newPerson.UpdateSuffix(value));
        }
        [Fact]
        public void Should_Throw_PersonArgumentException_For_Invalid_Gender()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            string newGender = "X";

            // Act/Assert
            Assert.Throws<PersonArgumentException>(() => newPerson.UpdateGender(newGender));
        }
        [Fact]
        public void Should_Throw_PersonArgumentException_For_Invalid_Race()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            string newRace = "X";

            // Act/Assert
            Assert.Throws<PersonArgumentException>(() => newPerson.UpdateRace(newRace));
        }
        [Fact]
        public void Should_Throw_PersonArgumentException_For_Invalid_DOB()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            DateTime newDOB = new DateTime();

            // Act/Assert
            Assert.Throws<PersonArgumentException>(() => newPerson.UpdateDOB(newDOB));
        }
        [Theory]
        [InlineData("219099999")]
        [InlineData("")]
        [InlineData("666123456")]
        public void Should_Throw_PersonArgumentException_For_Invalid_SSN(string value)
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            string newSSN = value;

            // Act/Assert
            Assert.Throws<PersonArgumentException>(() => newPerson.UpdateSSN(newSSN));

        }
        [Fact]
        public void Should_Throw_PersonArgumentException_Removing_PhoneNumber_Not_In_Collection()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            PhoneNumber newNumber = new PhoneNumber("1234567890", new PhoneNumberType("Test", "X"));
            PhoneNumber newNumber2 = new PhoneNumber("1234567890", new PhoneNumberType("Test2", "XX"));
            newPerson.AddPhoneNumber(newNumber);

            // Act/Assert
            Assert.Throws<PersonArgumentException>(() => newPerson.RemovePhoneNumber(newNumber2));
        }
        [Fact]
        public void Should_Throw_PersonArgumentException_Removing_Address_Not_In_Collection()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            Address newAddress = new Address(new AddressType("Home", "H"), "999 Main St.", "", "HomeTown", "AK", "12345");
            Address newAddress2 = new Address(new AddressType("Work", "W"), "123 Main St.", "", "HomeTown", "AK", "12345");
            newPerson.AddAddress(newAddress);

            // Act/Assert
            Assert.Throws<PersonArgumentException>(() => newPerson.RemoveAddress(newAddress2));
        }
        [Fact]
        public void Should_Throw_PersonArgumentException_Removing_Email_Not_In_Collection()
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();
            EmailAddress firstEmail = new EmailAddress("test@test.com");
            EmailAddress secondEmail = new EmailAddress("test2@test2.com");
            newPerson.AddEmailAddress(firstEmail);
            int initialEmailCount = newPerson.EmailAddresses.Count();

            // Act/Assert
            Assert.Equal(1, initialEmailCount);
            Assert.Throws<PersonArgumentException>(() => newPerson.RemoveEmailAddress(secondEmail));
            

        }
        [Theory]
        [InlineData(-1)]
        [InlineData(151)]
        public void Should_Throw_PersonArgumentException_For_Height_Out_Of_Range(int value)
        {
            // Arrange
            Person newPerson = _factory.CreatePerson();

            // Act/Assert
            Assert.Throws<PersonArgumentException>(() => newPerson.UpdateHeight(value));
        }

    }
}
