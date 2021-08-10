using Xunit;

namespace CaseCore.Domain.UnitTests.Common
{
    public class ValueObjectTests : EntityTestBase
    {
        [Fact]
        public void Equals_GivenDifferentValues_ShouldReturnFalse()
        {
            // Arrange/Act
            var point1 = new TestEntityFactory.Point(1, 2);
            var point2 = new TestEntityFactory.Point(2, 1);

            // Assert
            Assert.False(point1.Equals(point2));
        }
        [Fact]
        public void Equals_GivenMatchingValues_ShouldReturnTrue()
        {
            // Arrange/Act
            var point1 = new TestEntityFactory.Point(1, 2);
            var point2 = new TestEntityFactory.Point(1, 2);

            // Assert
            Assert.True(point1.Equals(point2));
        }
    }
}
