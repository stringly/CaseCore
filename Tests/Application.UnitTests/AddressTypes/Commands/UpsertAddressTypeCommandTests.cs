using CaseCore.Application.AddressTypes.Commands.UpsertAddressType;
using CaseCore.Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.AddressTypes.Commands
{
    public class UpsertAddressTypeCommandTests : CommandTestBase
    {
        private readonly UpsertAddressTypeCommandHandler _sut;

        public UpsertAddressTypeCommandTests() : base()
        {
            _sut = new UpsertAddressTypeCommandHandler(_context);
        }
        [Fact]
        public async Task Handle_Given_Valid_Values_Can_Create_AddressType()
        {
            // Arrange
            var validName = "Test Address Type";
            var validAbbreviation = "X";

            var command = new UpsertAddressTypeCommand
            {
                Name = validName,
                Abbreviation = validAbbreviation
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var newType = _context.AddressTypes.FirstOrDefaultAsync(x => x.Name == validName);
            Assert.NotNull(newType);
            Assert.Equal(6, _context.AddressTypes.Count());
        }
        [Fact]
        public async Task Can_Update_AddressType_Name()
        {
            // Arrange
            var newName = "New Address Name";
            var command = new UpsertAddressTypeCommand
            {
                Id = 1,
                Name = newName
            };
            var validator = new UpsertAddressTypeCommandValidator(_context);

            // Act
            var validationResult = await validator.ValidateAsync(command);
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var updatedType = _context.AddressTypes.Find(1);
            Assert.True(validationResult.IsValid);
            Assert.NotNull(updatedType);
            Assert.Equal(newName, updatedType.Name);
            Assert.Equal("LOI", updatedType.Abbreviation);
            Assert.Equal(5, _context.AddressTypes.Count());
        }
        [Fact]
        public async Task Can_Update_AddressType_Abbreviation()
        {
            // Arrange
            var newAbbreviation = "XXX";
            var command = new UpsertAddressTypeCommand
            {
                Id = 1,
                Abbreviation = newAbbreviation
            };
            var validator = new UpsertAddressTypeCommandValidator(_context);

            // Act
            var validationResult = await validator.ValidateAsync(command);
            await _sut.Handle(command, CancellationToken.None);
            // Assert
            var updatedType = _context.AddressTypes.Find(1);
            Assert.True(validationResult.IsValid);
            Assert.NotNull(updatedType);
            Assert.Equal(newAbbreviation, updatedType.Abbreviation);
            Assert.Equal("Location of Incident", updatedType.Name);
            Assert.Equal(5, _context.AddressTypes.Count());
        }
        [Fact]
        public async Task Validate_Taken_Name_Fails_Validation_On_Insert()
        {
            // Arrange
            var takenName = "Location of Incident";
            var validAbbreviation = "XX";
            var command = new UpsertAddressTypeCommand
            {
                Name = takenName,
                Abbreviation = validAbbreviation
            };
            var validator = new UpsertAddressTypeCommandValidator(_context);
            
            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Name"));
        }
        [Fact]
        public async Task Validate_Taken_Abbreviaton_Fails_Validation_On_Insert()
        {
            // Arrange
            var validName = "Test Address Type";
            var takenAbbreviation = "LOI";

            var command = new UpsertAddressTypeCommand
            {
                Name = validName,
                Abbreviation = takenAbbreviation
            };
            var validator = new UpsertAddressTypeCommandValidator(_context);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Abbreviation"));
        }
        [Theory]
        [InlineData("    ")]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXX")]
        public async Task Validate_Invalid_Name_Fails_Validation_On_Insert(string value)
        {
            // Arrange
            var invalidName = value;
            var validAbbreviation = "X";

            var command = new UpsertAddressTypeCommand
            {
                Name = invalidName,
                Abbreviation = validAbbreviation
            };
            var validator = new UpsertAddressTypeCommandValidator(_context);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Name"));
        }
        [Theory]
        [InlineData("   ")]
        [InlineData("XXXXXX")]
        public async Task Validate_Invalid_Abbreviation_Fails_Validation_On_Insert(string value)
        {
            // Arrange
            var validName = "Test Address Type";
            var invalidAbbreviation = value;
            var command = new UpsertAddressTypeCommand
            {
                Name = validName,
                Abbreviation = invalidAbbreviation
            };
            var validator = new UpsertAddressTypeCommandValidator(_context);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Abbreviation"));
        }
        [Fact]
        public async Task Validate_Taken_Name_Fails_Validation_On_Update()
        {
            // Arrange
            var takenName = "Location of Incident";
            var command = new UpsertAddressTypeCommand
            {
                Id = 2,
                Name = takenName                
            };
            var validator = new UpsertAddressTypeCommandValidator(_context);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Name"));
        }
        [Fact]
        public async Task Validate_Taken_Abbreviation_Fails_Validation_On_Update()
        {
            // Arrange
            var takenAbbreviation = "LOI";
            var command = new UpsertAddressTypeCommand
            {
                Id = 2,
                Abbreviation = takenAbbreviation
            };
            var validator = new UpsertAddressTypeCommandValidator(_context);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Abbreviation"));
        }
        [Fact]
        public async Task Validate_Null_Name_And_Abbreviation_Fails_Validation_On_Update()
        {
            // Arrange
            var Id = 1;
            var nullName = "";
            var nullAbbrev = "";

            var command = new UpsertAddressTypeCommand
            {
                Id = Id,
                Name = nullName,
                Abbreviation = nullAbbrev
            };
            var validator = new UpsertAddressTypeCommandValidator(_context);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Abbreviation"));
        }
        [Fact]
        public async Task Validate_Null_Name_And_Abbreviation_Fails_Validation_On_Insert()
        {
            // Arrange
            var nullName = "";
            var nullAbbrev = "";

            var command = new UpsertAddressTypeCommand
            {
                Name = nullName,
                Abbreviation = nullAbbrev
            };
            var validator = new UpsertAddressTypeCommandValidator(_context);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Abbreviation"));

        }
    }
}
