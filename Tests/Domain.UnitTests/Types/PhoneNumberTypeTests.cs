using CaseCore.Domain.Types;
using CaseCore.Domain.Exceptions.Types;
using Xunit;
using CaseCore.Domain.UnitTests.Common;

namespace CaseCore.Domain.UnitTests.Types
{
    public class PhoneNumberTypeTests : EntityTestBase
    {
        [Fact]
        public void Given_Valid_Values_PhoneType_Is_Valid()
        {
            // Arrange/Act
            var type = _factory.CreatePhoneNumberType();

            // Assert
            Assert.Equal("Test", type.Name);
            Assert.Equal("X", type.Abbreviation);
        }
        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData("qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm")]
        public void Should_Throw_PhoneTypeArgumentException_For_Invalid_Name(string value)
        {
            // Arrange
            string abbreviation = "H";
            
            // Act/Assert
            Assert.Throws<PhoneNumberTypeArgumentException>(() => new PhoneNumberType(value, abbreviation));            
        }
        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData("qwertyu")]
        public void Should_Throw_PhoneTypeArgumentException_For_Invalid_Abbreviation(string value)
        {
            // Arrange
            string name = "Home";

            // Act/Assert
            Assert.Throws<PhoneNumberTypeArgumentException>(() => new PhoneNumberType(name, value));
        }

        [Fact]
        public void Can_Update_FullName()
        {
            // Arrange
            var newType = _factory.CreatePhoneNumberType();
            var newName = "Work";

            // Act
            newType.UpdateFullName(newName);

            // Assert
            Assert.Equal(newType.Name, newName);
        }
        [Fact]
        public void Can_Update_Abbreviation()
        {
            // Arrange
            var newType = _factory.CreatePhoneNumberType();
            var newAbbreviation = "W";

            // Act
            newType.UpdateAbbreviation(newAbbreviation);

            // Assert
            Assert.Equal(newType.Abbreviation, newAbbreviation);
        }
    }
}
