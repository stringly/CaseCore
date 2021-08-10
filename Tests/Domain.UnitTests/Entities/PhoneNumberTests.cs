using CaseCore.Domain.Entities;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using CaseCore.Domain.UnitTests.Common;
using Xunit;

namespace CaseCore.Domain.UnitTests.Entities
{
    public class PhoneNumberTests : EntityTestBase
    {        
        [Fact]
        public void Given_Valid_Values_PhoneNumber_Is_Valid()
        {
            // Arrange
            string number = "1234567890";
            PhoneNumberType testType = _factory.CreatePhoneNumberType();

            // Act
            PhoneNumber newNumber = new PhoneNumber(number, testType);

            // Assert
            Assert.Equal(number, newNumber.Number);
            Assert.Equal(testType, newNumber.PhoneNumberType);
            Assert.Equal("(123) 456-7890", newNumber.PhoneNumberFormatted);            
        }
        [Theory]
        [InlineData("(123) 456-7890")]
        [InlineData("123-456-7890")]
        [InlineData("123 456 7890")]
        public void Should_Sanitize_Non_Numeric_Characters(string value)
        {
            // Arrange
            string number = value;
            PhoneNumberType testType = _factory.CreatePhoneNumberType();

            // Act
            PhoneNumber newNumber = new PhoneNumber(number, testType);

            // Assert
            Assert.Equal("1234567890", newNumber.Number);
            Assert.Equal(testType, newNumber.PhoneNumberType);
            Assert.Equal("(123) 456-7890", newNumber.PhoneNumberFormatted);
        }
        [Theory]
        [InlineData("QWERTYUIOP")]
        [InlineData("")]
        [InlineData("          ")]
        public void Should_Throw_PhoneNumberArgumentException_For_Invalid_Number(string value)
        {
            // Arrange
            string number = value;
            PhoneNumberType testType = _factory.CreatePhoneNumberType();

            // Act/Assert
            Assert.Throws<PhoneNumberArgumentException>(() => new PhoneNumber(number, testType));
            
        }
    }
}
