using CaseCore.Domain.Exceptions.Types;
using CaseCore.Domain.Types;
using CaseCore.Domain.UnitTests.Common;
using Xunit;

namespace CaseCore.Domain.UnitTests.Types
{
    public class CaseStatusTypeTests : EntityTestBase
    {
        [Fact]
        public void Given_Valid_Values_CaseStatusType_Is_Valid()
        {
            // Arrange/Act
            CaseStatusType newStatusType = _factory.CreateCaseStatusType();

            // Assert
            Assert.Equal("Test", newStatusType.Name);
        }
        [Fact]
        public void Can_Update_Name()
        {
            // Arrange            
            CaseStatusType newCaseStatusType = _factory.CreateCaseStatusType();
            string initialName = newCaseStatusType.Name;
            string newName = "Closed";

            // Act
            newCaseStatusType.UpdateName(newName);

            // Assert
            Assert.Equal("Test", initialName);
            Assert.Equal(newName, newCaseStatusType.Name);

        }

        [Theory]
        [InlineData("")]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXX")]
        [InlineData("          ")]
        public void Should_Throw_CaseStatusTypeArgumentException_For_Invalid_StatusName(string value)
        {
            // Arrange
            string name = value;

            // Act/Assert
            Assert.Throws<CaseStatusTypeArgumentException>(() => new CaseStatusType(name));
        }
    }
}
