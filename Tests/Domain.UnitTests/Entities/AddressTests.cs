using CaseCore.Domain.Entities;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using Xunit;

namespace CaseCore.Domain.UnitTests.Entities
{
    public class AddressTests
    {
        [Fact]
        public void Given_Valid_Values_Address_Is_Valid()
        {
            // Arrange
            int typeId = 1;
            string street = "123 Anywhere St.";
            string suite = "Apartment #3";
            string city = "Yourtown";
            string state = "MD";
            string zip = "12345";

            // Act
            Address newAddress = new Address(typeId, street, suite, city, state, zip);

            // Assert
            Assert.Equal("123 Anywhere St.", newAddress.Street);
            Assert.Equal("Apartment #3", newAddress.Suite);
            Assert.Equal("Yourtown", newAddress.City);
            Assert.Equal("MD", newAddress.StatePostalCode);
            Assert.Equal("12345", newAddress.Zip);
            Assert.Equal("123 Anywhere St. Apartment #3, Yourtown, MD 12345", newAddress.FullAddressText);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Should_Throw_AddressArgumentException_For_Invalid_AddressTypeId(int value)
        {
            // Arrange
            int typeId = value;
            string street = "123 Anywhere St.";
            string suite = "Apartment #3";
            string city = "Yourtown";
            string state = "MD";
            string zip = "12345";

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => new Address(typeId, street, suite, city, state, zip));
        }
        [Theory]
        [InlineData(0)]
        [InlineData(501)]
        public void Should_Throw_AddressArgumentException_For_Invalid_Street(int length)
        {
            // Arrange
            int typeId = 1;
            string street = new string('*', length);
            string suite = "Apartment #3";
            string city = "Yourtown";
            string state = "MD";
            string zip = "12345";

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => new Address(typeId, street, suite, city, state, zip));
        }

        [Fact]
        public void Should_Throw_AddressArgumentException_For_Invalid_Suite()
        {
            // Arrange
            int typeId = 1;
            string street = "123 Anywhere St.";
            string suite = new string('*', 501);
            string city = "Yourtown";
            string state = "MD";
            string zip = "12345";

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => new Address(typeId, street, suite, city, state, zip));
        }
        [Theory]
        [InlineData(0)]
        [InlineData(501)]
        public void Should_Throw_AddressArgumentException_For_Invalid_City(int length)
        {
            // Arrange
            int typeId = 1;
            string street = "123 Anywhere St.";
            string suite = "Apartment #3";
            string city = new string('*', length);
            string state = "MD";
            string zip = "12345";

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => new Address(typeId, street, suite, city, state, zip));
        }
        [Theory]
        [InlineData("XX")]
        [InlineData("")]
        [InlineData("     ")]
        public void Should_Throw_AddressArgumentException_For_Invalid_Zip(string value)
        {
            // Arrange
            int typeId = 1;
            string street = "123 Anywhere St.";
            string suite = "Apartment #3";
            string city = "Yourtown";
            string state = "MD";
            string zip = value;

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => new Address(typeId, street, suite, city, state, zip));
        }
        
        [Fact]
        public void Given_Valid_Values_Address_With_AddressMeta_Is_Valid()
        {
            // Arrange
            int typeId = 1;
            string street = "123 Anywhere St.";
            string suite = "Apartment #3";
            string city = "Yourtown";
            string state = "MD";
            string zip = "12345";
            string beat = "A1";
            string ra = "113";
            double latitude = 89.0;
            double longitude = 179.0;
            var meta = new AddressMeta(beat, ra, latitude, longitude);

            // Act
            Address newAddress = new Address(typeId, street, suite, city, state, zip, meta);

            // Assert
            Assert.Equal(89.0, newAddress.Latitude);
            Assert.Equal(179.0, newAddress.Longitude);
            Assert.Equal("A1", newAddress.Beat);
            Assert.Equal("113", newAddress.ReportingArea);
        }
    }
}
