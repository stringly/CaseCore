﻿using CaseCore.Domain.Types;
using CaseCore.Domain.Exceptions.Types;
using Xunit;

namespace CaseCore.Domain.UnitTests.Types
{
    public class OffenseTypeTests
    {
        [Fact]
        public void Given_Valid_Values_OffenseType_Is_Valid()
        {
            // Arrange
            string name = "Home";
            string abbreviation = "H";

            // Act
            var type = new OffenseType(name, abbreviation);

            // Assert
            Assert.Equal("Home", type.Name);
            Assert.Equal("H", type.Abbreviation);
        }
        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData("qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm")]
        public void Should_Throw_OffenseTypeArgumentException_For_Invalid_Name(string value)
        {
            // Arrange
            string abbreviation = "H";
            
            // Act/Assert
            Assert.Throws<OffenseTypeArgumentException>(() => new OffenseType(value, abbreviation));            
        }
        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData("qwertyu")]
        public void Should_Throw_OffenseTypeArgumentException_For_Invalid_Abbreviation(string value)
        {
            // Arrange
            string name = "Home";

            // Act/Assert
            Assert.Throws<OffenseTypeArgumentException>(() => new OffenseType(name, value));
        }

        [Fact]
        public void Can_Update_FullName()
        {
            // Arrange
            var newType = new OffenseType("Home", "H");
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
            var newType = new OffenseType("Home", "H");
            var newAbbreviation = "W";

            // Act
            newType.UpdateAbbreviation(newAbbreviation);

            // Assert
            Assert.Equal(newType.Abbreviation, newAbbreviation);
        }
    }
}