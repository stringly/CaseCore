using CaseCore.Domain.Types;
using CaseCore.Domain.Exceptions.Types;
using Xunit;

namespace CaseCore.Domain.UnitTests.Types
{
    public class AddressMetaTests
    {
        [Fact]
        public void Given_Valid_Values_AddressMeta_Is_Valid()
        {
            // Arrange
            string beat = "A1";
            string ra = "113";
            double latitude = 89.0;
            double longitude = 179.0;

            // Act
            var meta = new AddressMeta(beat, ra, latitude, longitude);

            // Assert
            Assert.Equal(beat, meta.Beat);
            Assert.Equal(ra, meta.ReportingArea);
            Assert.Equal(latitude, meta.Latitude);
            Assert.Equal(longitude, meta.Longitude);
        } 
        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData("qwertyu")]
        public void Should_Throw_AddressMetaArgumentException_For_Invalid_Beat(string value)
        {
            // Arrange
            string beat = value;
            string ra = "113";
            double latitude = 89.0;
            double longitude = 179.0;

            // Act/Assert
            Assert.Throws<AddressMetaArgumentException>(() => new AddressMeta(beat, ra, latitude, longitude));
        }
        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        [InlineData("qwertyuiopas")]
        public void Should_Throw_AddressMetaArgumentException_For_Invalid_ReportingArea(string value)
        {
            // Arrange
            string beat = "A1";
            string ra = value;
            double latitude = 89.0;
            double longitude = 179.0;

            // Act/Assert
            Assert.Throws<AddressMetaArgumentException>(() => new AddressMeta(beat, ra, latitude, longitude));
        }
        [Theory]
        [InlineData(-90.1)]
        [InlineData(90.1)]
        public void Should_Throw_AddressMetaArgumentException_For_Invalid_Latitude(double value)
        {
            // Arrange
            string beat = "A1";
            string ra = "113";
            double latitude = value;
            double longitude = 179.0;

            // Act/Assert
            Assert.Throws<AddressMetaArgumentException>(() => new AddressMeta(beat, ra, latitude, longitude));

        }
        [Theory]
        [InlineData(-180.1)]
        [InlineData(180.1)]
        public void Should_Throw_AddressMetaArgumentException_For_Invalid_Longitude(double value)
        {
            // Arrange
            string beat = "A1";
            string ra = "113";
            double latitude = 89.0;
            double longitude = value;

            // Act/Assert
            Assert.Throws<AddressMetaArgumentException>(() => new AddressMeta(beat, ra, latitude, longitude));

        }
    }
}
