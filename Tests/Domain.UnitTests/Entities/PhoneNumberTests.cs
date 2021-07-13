using CaseCore.Domain.Entities;
using CaseCore.Domain.Exceptions.Entities;
using Xunit;

namespace CaseCore.Domain.UnitTests.Entities
{
    public class PhoneNumberTests
    {
        [Fact]
        public void Given_Valid_Values_PhoneNumber_Is_Valid()
        {
            // Arrange
            string number = "1234567890";
            int type = 1;

            // Act
            PhoneNumber newNumber = new PhoneNumber(number, type);

            // Assert
            Assert.Equal(number, newNumber.Number);
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
            int type = 1;

            // Act
            PhoneNumber newNumber = new PhoneNumber(number, type);

            // Assert
            Assert.Equal("1234567890", newNumber.Number);
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
            int type = 1;

            // Act/Assert
            Assert.Throws<PhoneNumberArgumentException>(() => new PhoneNumber(number, type));
            
        }
    }
}
