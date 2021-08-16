using CaseCore.Application.PersonTypes.Commands.UpsertPersonType;
using CaseCore.Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.PersonTypes.Commands
{
    public class UpsertPersonTypeCommandTests : CommandTestBase
    {
        private readonly UpsertPersonTypeCommandHandler _sut;

        public UpsertPersonTypeCommandTests() : base()
        {
            _sut = new UpsertPersonTypeCommandHandler(_context);
        }
        [Fact]
        public async Task Handle_Given_Valid_Values_Can_Create_PersonType()
        {
            // Arrange
            var validName = "Test Person Type";
            var validAbbrev = "XX";


            var command = new UpsertPersonTypeCommand
            {
                Name = validName,
                Abbreviation = validAbbrev
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var newType = _context.PersonTypes.FirstOrDefaultAsync(x => x.Name == validName);
            Assert.NotNull(newType);
            Assert.Equal(8, _context.PersonTypes.Count());
        }
        [Fact]
        public async Task Can_Update_PersonType_Name()
        {
            // Arrange
            var newName = "Updated Person Type Name";
            var command = new UpsertPersonTypeCommand
            {
                Id = 1,
                Name = newName
            };
            var validator = new UpsertPersonTypeCommandValidator(_context);

            // Act
            var validationResult = await validator.ValidateAsync(command);
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var updatedType = _context.PersonTypes.Find(1);
            Assert.True(validationResult.IsValid);
            Assert.NotNull(updatedType);
            Assert.Equal(newName, updatedType.Name);
            Assert.Equal(7, _context.PersonTypes.Count());
        }
        [Fact]
        public async Task Validate_Taken_Name_Fails_Validation_On_Insert()
        {
            // Arrange
            var takenName = "Victim";
            var validAbbrev = "XX";

            var command = new UpsertPersonTypeCommand
            {
                Name = takenName,
                Abbreviation = validAbbrev
            };
            var validator = new UpsertPersonTypeCommandValidator(_context);

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

            var command = new UpsertPersonTypeCommand
            {
                Name = invalidName,
                Abbreviation = validAbbrev
            };
            var validator = new UpsertPersonTypeCommandValidator(_context);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Name"));
        }
    }
}
