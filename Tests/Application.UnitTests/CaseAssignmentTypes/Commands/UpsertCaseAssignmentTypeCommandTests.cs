using CaseCore.Application.CaseAssignmentTypes.Commands.UpsertCaseAssignmentType;
using CaseCore.Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.CaseAssignmentTypes.Commands
{
    public class UpsertCaseAssignmentTypeCommandTests : CommandTestBase
    {
        private readonly UpsertCaseAssignmentTypeCommandHandler _sut;

        public UpsertCaseAssignmentTypeCommandTests() : base()
        {
            _sut = new UpsertCaseAssignmentTypeCommandHandler(_context);
        }
        [Fact]
        public async Task Handle_Given_Valid_Values_Can_Create_CaseAssignmentType()
        {
            // Arrange
            var validName = "Test Case Assignment Type";
            

            var command = new UpsertCaseAssignmentTypeCommand
            {
                Name = validName
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var newType = _context.CaseAssignmentTypes.FirstOrDefaultAsync(x => x.Name == validName);
            Assert.NotNull(newType);
            Assert.Equal(3, _context.CaseAssignmentTypes.Count());
        }
        [Fact]
        public async Task Can_Update_CaseAssignmentType_Name()
        {
            // Arrange
            var newName = "New Address Name";
            var command = new UpsertCaseAssignmentTypeCommand
            {
                Id = 1,
                Name = newName
            };
            var validator = new UpsertCaseAssignmentTypeCommandValidator(_context);

            // Act
            var validationResult = await validator.ValidateAsync(command);
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var updatedType = _context.CaseAssignmentTypes.Find(1);
            Assert.True(validationResult.IsValid);
            Assert.NotNull(updatedType);
            Assert.Equal(newName, updatedType.Name);
            Assert.Equal(2, _context.CaseAssignmentTypes.Count());
        }
        [Fact]
        public async Task Validate_Taken_Name_Fails_Validation_On_Insert()
        {
            // Arrange
            var takenName = "Initial";
            
            var command = new UpsertCaseAssignmentTypeCommand
            {
                Name = takenName
            };
            var validator = new UpsertCaseAssignmentTypeCommandValidator(_context);

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

            var command = new UpsertCaseAssignmentTypeCommand
            {
                Name = invalidName
            };
            var validator = new UpsertCaseAssignmentTypeCommandValidator(_context);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Name"));
        }
    }
}
