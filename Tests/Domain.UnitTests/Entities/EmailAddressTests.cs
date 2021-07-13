using CaseCore.Domain.Entities;
using CaseCore.Domain.Exceptions.Entities;
using Xunit;

namespace CaseCore.Domain.UnitTests.Entities
{
    public class EmailAddressTests
    {
        [Fact]
        public void Given_Valid_Values_EmailAddress_Is_Valid()
        {
            // Arrange
            string address = "test@test.com";

            // Act
            EmailAddress newAddress = new EmailAddress(address);

            // Assert
            Assert.Equal(address, newAddress.Address);                
        }

        [Theory]
        [InlineData(0)]
        [InlineData(51)]
        public void Should_Throw_EmailAddressArgumentException_For_Invalid_Address_Length(int value)
        {
            // Arrange
            string address = new string('*', value);

            // Act/Assert
            Assert.Throws<EmailAddressArgumentException>(() => new EmailAddress(address));
        }

        [Theory]
        [InlineData("")]
        [InlineData("      ")]
        [InlineData("                                ")]
        public void Should_Throw_EmailAddressArgumentException_For_Invalid_Address(string value)
        {
            // Arrange
            string address = value;

            // Act/Assert
            Assert.Throws<EmailAddressArgumentException>(() => new EmailAddress(address));
        }

    }
}
