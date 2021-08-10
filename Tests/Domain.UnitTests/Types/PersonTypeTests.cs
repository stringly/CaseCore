using CaseCore.Domain.Types;
using CaseCore.Domain.Exceptions.Types;
using Xunit;
using CaseCore.Domain.UnitTests.Common;

namespace CaseCore.Domain.UnitTests.Types
{
    public class PersonTypeTests : EntityTestBase
    {
        [Fact]
        public void Given_Valid_Values_PersonType_Is_Valid()
        {
            // Arrange/Act            
            var type = _factory.CreatePersonType();

            // Assert
            Assert.Equal("Test", type.Name);
            Assert.Equal("X", type.Abbreviation);
        }
        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData("qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm")]
        public void Should_Throw_PersonTypeArgumentException_For_Invalid_Name(string value)
        {
            // Arrange
            string abbreviation = "V";
            
            // Act/Assert
            Assert.Throws<PersonTypeArgumentException>(() => new PersonType(value, abbreviation));            
        }
        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData("qwertyu")]
        public void Should_Throw_PersonTypeArgumentException_For_Invalid_Abbreviation(string value)
        {
            // Arrange
            string name = "Victim";

            // Act/Assert
            Assert.Throws<PersonTypeArgumentException>(() => new PersonType(name, value));
        }

        [Fact]
        public void Can_Update_FullName()
        {
            // Arrange
            var newType = _factory.CreatePersonType();
            var newName = "Suspect";

            // Act
            newType.UpdateFullName(newName);

            // Assert
            Assert.Equal(newType.Name, newName);
        }
        [Fact]
        public void Can_Update_Abbreviation()
        {
            // Arrange
            var newType = _factory.CreatePersonType();
            var newAbbreviation = "S";

            // Act
            newType.UpdateAbbreviation(newAbbreviation);

            // Assert
            Assert.Equal(newType.Abbreviation, newAbbreviation);
        }
    }
}
