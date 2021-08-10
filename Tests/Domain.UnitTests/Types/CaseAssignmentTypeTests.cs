using CaseCore.Domain.Exceptions.Types;
using CaseCore.Domain.Types;
using CaseCore.Domain.UnitTests.Common;
using Xunit;

namespace CaseCore.Domain.UnitTests.Types
{
    public class CaseAssignmentTypeTests : EntityTestBase
    {
        [Fact]
        public void Given_Valid_Values_CaseAssignmentType_Is_Valid()
        {
            // Arrange/Act
            CaseAssignmentType newType = _factory.CreateCaseAssignmentType();

            // Assert
            Assert.Equal("Test", newType.Name);
        }
        [Fact]
        public void Can_Update_Name()
        {
            // Arrange
            CaseAssignmentType newType = _factory.CreateCaseAssignmentType();
            string initialName = newType.Name;
            string newName = "Reassigned";

            // Act
            newType.UpdateName(newName);

            // Assert
            Assert.Equal("Test", initialName);
            Assert.Equal(newName, newType.Name);

        }

        [Theory]
        [InlineData("")]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXX")]
        [InlineData("          ")]
        public void Should_Throw_CaseAssignmentTypeArgumentException_For_Invalid_StatusName(string value)
        {
            // Arrange
            string name = value;

            // Act/Assert
            Assert.Throws<CaseAssignmentTypeArgumentException>(() => new CaseAssignmentType(name));
        }
    }
}
