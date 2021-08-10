using CaseCore.Domain.Types;
using CaseCore.Domain.Exceptions.Types;
using Xunit;
using CaseCore.Domain.UnitTests.Common;

namespace CaseCore.Domain.UnitTests.Types
{
    public class OffenseTypeTests : EntityTestBase
    {
        [Fact]
        public void Given_Valid_Values_OffenseType_Is_Valid()
        {
            // Arrange
            OffenseType newType = _factory.CreateOffenseType();

            // Assert
            Assert.Equal("Test", newType.Name);
            Assert.Equal("X", newType.Abbreviation);
        }
        [Fact]
        public void Can_Update_Name()
        {
            // Arrange
            OffenseType newType = _factory.CreateOffenseType();
            string newName = "Homicide";

            // Act
            newType.UpdateFullName(newName);

            // Assert
            Assert.Equal(newName, newType.Name);
        }
        [Fact]
        public void Can_Update_Abbreviation()
        {
            // Arrange
            OffenseType newType = _factory.CreateOffenseType();
            string newAbbreviation = "H";

            // Act
            newType.UpdateAbbreviation(newAbbreviation);

            // Assert
            Assert.Equal(newAbbreviation, newType.Abbreviation);
        }
        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        [InlineData("D")]
        public void Should_Throw_OffenseTypeArgumentException_For_Invalid_Name(string value)
        {
            // Arrange
            OffenseType newType = _factory.CreateOffenseType();            

            // Act/Assert
            Assert.Throws<OffenseTypeArgumentException>(() => newType.UpdateFullName(value));
        }
        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData("DDDDDD")]
        public void Should_Throw_OffenseTypeArgumentException_For_Invalid_Abbreviation(string value)
        {
            // Arrange
            OffenseType newType = _factory.CreateOffenseType();
            
            // Act/Assert
            Assert.Throws<OffenseTypeArgumentException>(() => newType.UpdateAbbreviation(value));
        }
    }
}
