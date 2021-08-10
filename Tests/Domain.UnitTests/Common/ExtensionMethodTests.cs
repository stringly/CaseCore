using CaseCore.Domain.Common;
using Xunit;

namespace CaseCore.Domain.UnitTests.Common
{
    public class ExtensionMethodTests : EntityTestBase
    {
        [Fact]
        public void Get_Enum_Description_Returns_Description()
        {
            // Arrange/Act/Assert
            Assert.Equal("This Enum has a description", TestEntityFactory.TestEnums.TestWithDescription.GetDescription());
            Assert.Null(TestEntityFactory.TestEnums.TestWithoutDescription.GetDescription());
        }
        [Fact]
        public void String_Remove_Non_Numeric_Characters_Removes_Non_Numeric_Characters()
        {
            // Arrange
            string withNonNumbers = "9999DASDASD888";

            // Act
            string withoutNonNumbers = withNonNumbers.RemoveNonNumericCharacters();

            // Assert
            Assert.Equal("9999888", withoutNonNumbers);
        }
        [Fact]
        public void String_Remove_Non_AlphaNumeric_Characters_Removes_Non_AlphaNumeric_Characters()
        {
            // Arrange
            string withSymbols = "111-AA-2222%";

            // Act
            string withoutSymbols = withSymbols.RemoveNonAlphanumericCharacters();

            // Assert
            Assert.Equal("111AA2222", withoutSymbols);
        }
    }
}
