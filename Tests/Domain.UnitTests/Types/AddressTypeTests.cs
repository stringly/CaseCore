using CaseCore.Domain.Types;
using CaseCore.Domain.Exceptions.Types;
using Xunit;
using CaseCore.Domain.UnitTests.Common;

namespace CaseCore.Domain.UnitTests.Types
{
    public class AddressTypeTests : EntityTestBase
    {
        
        [Fact]
        public void Given_Valid_Values_AddressType_Is_Valid()
        {
            // Arrange/Act
            AddressType newType = _factory.CreateAddressType();

            // Assert
            Assert.Equal("Test", newType.Name);
            Assert.Equal("X", newType.Abbreviation);
        }
        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData("qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm")]
        public void Should_Throw_AddressTypeArgumentException_For_Invalid_Name(string value)
        {
            // Arrange
            string abbreviation = "H";
            
            // Act/Assert
            Assert.Throws<AddressTypeArgumentException>(() => new AddressType(value, abbreviation));            
        }
        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData("qwertyu")]
        public void Should_Throw_AddressTypeArgumentException_For_Invalid_Abbreviation(string value)
        {
            // Arrange
            string name = "Home";

            // Act/Assert
            Assert.Throws<AddressTypeArgumentException>(() => new AddressType(name, value));
        }

        [Fact]
        public void Can_Update_FullName()
        {
            // Arrange
            var newType = _factory.CreateAddressType();
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
            var newType = _factory.CreateAddressType();
            var newAbbreviation = "W";

            // Act
            newType.UpdateAbbreviation(newAbbreviation);

            // Assert
            Assert.Equal(newType.Abbreviation, newAbbreviation);
        }
    }
}
