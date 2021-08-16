using CaseCore.Application.CaseStatusTypes.Commands.UpsertCaseStatusType;
using CaseCore.Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.CaseStatusTypes.Commands
{
    public class UpsertCaseStatusTypeCommandTests : CommandTestBase
    {
        private readonly UpsertCaseStatusTypeCommandHandler _sut;

        public UpsertCaseStatusTypeCommandTests() : base()
        {
            _sut = new UpsertCaseStatusTypeCommandHandler(_context);
        }
        [Fact]
        public async Task Handle_Given_Valid_Values_Can_Create_CaseStatusType()
        {
            // Arrange
            var validName = "Test Case Status Type";


            var command = new UpsertCaseStatusTypeCommand
            {
                Name = validName
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var newType = _context.CaseStatusTypes.FirstOrDefaultAsync(x => x.Name == validName);
            Assert.NotNull(newType);
            Assert.Equal(6, _context.CaseStatusTypes.Count());
        }
        [Fact]
        public async Task Can_Update_CaseStatusType_Name()
        {
            // Arrange
            var newName = "Updated Case Status Name";
            var command = new UpsertCaseStatusTypeCommand
            {
                Id = 1,
                Name = newName
            };
            var validator = new UpsertCaseStatusTypeCommandValidator(_context);

            // Act
            var validationResult = await validator.ValidateAsync(command);
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var updatedType = _context.CaseStatusTypes.Find(1);
            Assert.True(validationResult.IsValid);
            Assert.NotNull(updatedType);
            Assert.Equal(newName, updatedType.Name);
            Assert.Equal(5, _context.CaseStatusTypes.Count());
        }
        [Fact]
        public async Task Validate_Taken_Name_Fails_Validation_On_Insert()
        {
            // Arrange
            var takenName = "Open";

            var command = new UpsertCaseStatusTypeCommand
            {
                Name = takenName
            };
            var validator = new UpsertCaseStatusTypeCommandValidator(_context);

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

            var command = new UpsertCaseStatusTypeCommand
            {
                Name = invalidName
            };
            var validator = new UpsertCaseStatusTypeCommandValidator(_context);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Name"));
        }
    }
}
