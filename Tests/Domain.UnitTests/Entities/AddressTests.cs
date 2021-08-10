using CaseCore.Domain.Entities;
using CaseCore.Domain.Exceptions.Entities.Address;
using CaseCore.Domain.Types;
using CaseCore.Domain.UnitTests.Common;
using Xunit;

namespace CaseCore.Domain.UnitTests.Entities
{
    public class AddressTests : EntityTestBase
    {
        [Fact]
        public void Can_Create_Address_Via_Constructor_1()
        {
            // Arrange/Act
            Address newAddress = _factory.CreateAddress();

            // Assert
            Assert.Equal("123 Anywhere St.", newAddress.Street);
            Assert.Equal("Apartment #3", newAddress.Suite);
            Assert.Equal("Yourtown", newAddress.City);
            Assert.Equal("MD", newAddress.StatePostalCode);
            Assert.Equal("12345", newAddress.Zip);
            Assert.Equal("123 Anywhere St. Apartment #3, Yourtown, MD 12345", newAddress.FullAddressText);

        }
        [Fact]
        public void Can_Create_Address_Via_Constructor_2()
        {
            // Arrange/Act
            Address newAddress = _factory.CreateAddress(2);

            // Assert
            Assert.Equal("123 Anywhere St.", newAddress.Street);
            Assert.Equal("Apartment #3", newAddress.Suite);
            Assert.Equal("Yourtown", newAddress.City);
            Assert.Equal("MD", newAddress.StatePostalCode);
            Assert.Equal("12345", newAddress.Zip);
            Assert.Equal("123 Anywhere St. Apartment #3, Yourtown, MD 12345", newAddress.FullAddressText);
            Assert.Equal(89.0, newAddress.Latitude);
            Assert.Equal(179.0, newAddress.Longitude);
        }
        [Fact]
        public void Can_Create_Address_Via_Constructor_3()
        {
            // Arrange/Act
            Address newAddress = _factory.CreateAddress(3);

            // Assert
            Assert.Equal("123 Anywhere St.", newAddress.Street);
            Assert.Equal("Apartment #3", newAddress.Suite);
            Assert.Equal("Yourtown", newAddress.City);
            Assert.Equal("MD", newAddress.StatePostalCode);
            Assert.Equal("12345", newAddress.Zip);
            Assert.Equal("123 Anywhere St. Apartment #3, Yourtown, MD 12345", newAddress.FullAddressText);
            Assert.Equal("B3", newAddress.Beat);
            Assert.Equal("118", newAddress.ReportingArea);

        }
        [Fact]
        public void Can_Create_Address_Via_Constructor_4()
        {
            // Arrange/Act
            Address newAddress = _factory.CreateAddress(4);

            // Assert
            Assert.Equal("123 Anywhere St.", newAddress.Street);
            Assert.Equal("Apartment #3", newAddress.Suite);
            Assert.Equal("Yourtown", newAddress.City);
            Assert.Equal("MD", newAddress.StatePostalCode);
            Assert.Equal("12345", newAddress.Zip);
            Assert.Equal("123 Anywhere St. Apartment #3, Yourtown, MD 12345", newAddress.FullAddressText);
            Assert.Equal(89.0, newAddress.Latitude);
            Assert.Equal(179.0, newAddress.Longitude);
            Assert.Equal("B3", newAddress.Beat);
            Assert.Equal("118", newAddress.ReportingArea);

        }
        [Fact]
        public void Can_Update_Street()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string newStreet = "999 Main St.";

            // Act
            newAddress.UpdateStreet(newStreet);

            // Assert
            Assert.Equal("999 Main St.", newAddress.Street);
        }
        [Fact]
        public void Can_Update_Suite()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string newSuite = "Suite #10";
            
            // Act
            newAddress.UpdateSuite(newSuite);

            // Assert 
            Assert.Equal("Suite #10", newAddress.Suite);
        }
        [Fact]
        public void Can_Update_City()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string newCity = "Anytown";

            // Act
            newAddress.UpdateCity(newCity);

            // Assert
            Assert.Equal("Anytown", newAddress.City);
        }
        [Fact]
        public void Can_Update_State()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string newState = "AK";

            // Act
            newAddress.UpdateState(newState);

            // Assert
            Assert.Equal("AK", newAddress.StatePostalCode);
        }
        [Fact]
        public void Can_Update_Zip()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string newZip = "55555";

            // Act
            newAddress.UpdateZip(newZip);

            // Assert
            Assert.Equal("55555", newAddress.Zip);
           
        }
        [Fact]
        public void Can_Update_Beat()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string newBeat = "A4";

            // Act
            newAddress.UpdateBeat(newBeat);

            // Assert
            Assert.Equal("A4", newAddress.Beat);
        }
        [Fact]
        public void Can_Update_ReportingArea()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string newReportingArea = "120";

            // Act
            newAddress.UpdateReportingArea(newReportingArea);

            // Assert
            Assert.Equal("120", newAddress.ReportingArea);
        }
        [Fact]
        public void Can_Update_Coordinate_Latitude()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress(2);
            double? newLatitude = 10.0;
            
            // Act
            newAddress.UpdateCoordinates(newLatitude);

            // Assert
            Assert.Equal(10.0, newAddress.Latitude);
            Assert.Equal(179.0, newAddress.Longitude);

        }
        [Fact]
        public void Can_Update_Coordinate_Longitude()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress(2);
            double? newLongitude = 150.0;

            // Act
            newAddress.UpdateCoordinates(longitude: newLongitude);

            // Assert
            Assert.Equal(89.0, newAddress.Latitude);
            Assert.Equal(150.0, newAddress.Longitude);

        }
        [Fact]
        public void Can_Update_AddressType()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            AddressType newType = new AddressType("New Address Type", "N");

            // Act
            newAddress.UpdateType(newType);

            // Assert
            Assert.Equal(newType.Name, newAddress.AddressType.Name);
        }
        [Fact]
        public void Can_Update_Coordinates_On_Address_With_Null_Coordinate_Properties()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress(); // Constructor 1 will not populate the Lat/Long properties.
            double? newLatitude = 80.0;
            double? newLongitude = 170.0;

            // Act
            newAddress.UpdateCoordinates(newLatitude, newLongitude);

            // Assert
            Assert.Equal(80.0, newAddress.Latitude);
            Assert.Equal(170.0, newAddress.Longitude);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(501)]
        public void Should_Throw_AddressArgumentException_For_Invalid_Street(int length)
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string street = new string('*', length);

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => newAddress.UpdateStreet(street));
        }

        [Fact]
        public void Should_Throw_AddressArgumentException_For_Invalid_Suite()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string suite = new string('*', 501);


            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => newAddress.UpdateSuite(suite));
        }
        [Theory]
        [InlineData(0)]
        [InlineData(501)]
        public void Should_Throw_AddressArgumentException_For_Invalid_City(int length)
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string city = new string('*', length);
            
            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => newAddress.UpdateCity(city));
        }
        [Fact]
        public void Should_Throw_AddressArgumentException_For_Invalid_State()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string invalidState = "XX";

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => newAddress.UpdateState(invalidState));
        }
        [Theory]
        [InlineData("XX")]
        [InlineData("")]
        [InlineData("     ")]
        public void Should_Throw_AddressArgumentException_For_Invalid_Zip(string value)
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string zip = value;

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => newAddress.UpdateZip(zip));
        }
        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("XXXXXX")]
        public void Should_Throw_AddressArgumentException_For_Invalid_Beat(string value)
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string beat = value;

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => newAddress.UpdateBeat(beat));
        }
        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("XXXXXXXXXXX")]
        public void Should_Throw_AddressArgumentException_For_Invalid_ReportingArea(string value)
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            string reportingArea = value;

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => newAddress.UpdateReportingArea(reportingArea));
        }
        [Theory]
        [InlineData(91.0)]
        [InlineData(-91.0)]
        public void Should_Throw_AddressArgumentException_For_Invalid_Coordinate_Latitude(double value)
        {
            // Arrange
            Address newAddress = _factory.CreateAddress(2);
            double latitude = value;            
            
            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => newAddress.UpdateCoordinates(latitude));
        }
        [Theory]
        [InlineData(191.0)]
        [InlineData(-191.0)]
        public void Should_Throw_AddressArgumentException_For_Invalid_Coordinate_Longitude(double value)
        {
            // Arrange
            Address newAddress = _factory.CreateAddress(2);
            double longitude = value;

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => newAddress.UpdateCoordinates(null, longitude));
        }
        [Fact]
        public void Should_Throw_AddressInvalidOperationException_For_Updated_Latitude_With_Null_Longitude_Property()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress(); // Constructor 1 will leave the lat/long properties null
            double? newLatitude = 10.0;

            // Act/Assert
            Assert.Throws<AddressInvalidOperationException>(() => newAddress.UpdateCoordinates(newLatitude));
        }
        [Fact]
        public void Should_Throw_AddressInvalidOperationException_For_Updated_Longitude_With_Null_Latitude_Property()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress(); // Constructor 1 will leave the lat/long properties null
            double? newLongitude = 150.0;

            // Act/Assert
            Assert.Throws<AddressInvalidOperationException>(() => newAddress.UpdateCoordinates(longitude: newLongitude));
        }
        [Fact]
        public void Should_Throw_AddressArgumentException_For_Invalid_Latitude_When_Both_Parameters_Provided()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            double? newLatitude = 91.0;
            double? newLongitude = 90.0;

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => newAddress.UpdateCoordinates(newLatitude, newLongitude));
        }
        [Fact]
        public void Should_Throw_AddressArgumentException_For_Invalid_Longitude_When_Both_Parameters_Provided()
        {
            // Arrange
            Address newAddress = _factory.CreateAddress();
            double? newLatitude = 80.0;
            double? newLongitude = 190.0;

            // Act/Assert
            Assert.Throws<AddressArgumentException>(() => newAddress.UpdateCoordinates(newLatitude, newLongitude));
        }
    }
}
