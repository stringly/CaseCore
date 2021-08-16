using CaseCore.Application.PhoneNumberTypes.Commands.UpsertPhoneNumberType;
using CaseCore.Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.PhoneNumberTypes.Commands
{
    public class UpsertPhoneNumberTypeCommandTests : CommandTestBase
    {
        private readonly UpsertPhoneNumberTypeCommandHandler _sut;

        public UpsertPhoneNumberTypeCommandTests() : base()
        {
            _sut = new UpsertPhoneNumberTypeCommandHandler(_context);
        }
        [Fact]
        public async Task Handle_Given_Valid_Values_Can_Create_PhoneNumberType()
        {
            // Arrange
            var validName = "New Phone Number Type";
            var validAbbrev = "XX";


            var command = new UpsertPhoneNumberTypeCommand
            {
                Name = validName,
                Abbreviation = validAbbrev
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var newType = _context.PhoneNumberTypes.FirstOrDefaultAsync(x => x.Name == validName);
            Assert.NotNull(newType);
            Assert.Equal(5, _context.PhoneNumberTypes.Count());
        }
        [Fact]
        public async Task Can_Update_PhoneNumberType_Name()
        {
            // Arrange
            var newName = "Updated Phone Number Type";
            var command = new UpsertPhoneNumberTypeCommand
            {
                Id = 1,
                Name = newName
            };
            var validator = new UpsertPhoneNumberTypeCommandValidator(_context);

            // Act
            var validationResult = await validator.ValidateAsync(command);
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var updatedType = _context.PhoneNumberTypes.Find(1);
            Assert.True(validationResult.IsValid);
            Assert.NotNull(updatedType);
            Assert.Equal(newName, updatedType.Name);
            Assert.Equal(4, _context.PhoneNumberTypes.Count());
        }
        [Fact]
        public async Task Validate_Taken_Name_Fails_Validation_On_Insert()
        {
            // Arrange
            var takenName = "Home";
            var validAbbrev = "XX";

            var command = new UpsertPhoneNumberTypeCommand
            {
                Name = takenName,
                Abbreviation = validAbbrev
            };
            var validator = new UpsertPhoneNumberTypeCommandValidator(_context);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Name"));
        }
        [Theory]
        [InlineData("    ")]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXX")]
        public async Task Validate_Invalid_Name_Fails_Validation_On_Insert(string value)
        {
            // Arrange
            var invalidName = value;
            var validAbbrev = "XX";

            var command = new UpsertPhoneNumberTypeCommand
            {
                Name = invalidName,
                Abbreviation = validAbbrev
            };
            var validator = new UpsertPhoneNumberTypeCommandValidator(_context);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Name"));
        }
    }
}
