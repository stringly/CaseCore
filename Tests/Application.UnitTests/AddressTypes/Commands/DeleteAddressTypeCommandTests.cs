using CaseCore.Application.AddressTypes.Commands.DeleteAddressType;
using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.UnitTests.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.AddressTypes.Commands
{
    public class DeleteAddressTypeCommandTests : CommandTestBase
    {
        private readonly DeleteAddressTypeCommandHandler _sut;

        public DeleteAddressTypeCommandTests() : base()
        {
            _sut = new DeleteAddressTypeCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_Given_Valid_Id_Can_Delete_AddressType()
        {
            // Arrange
            var validId = 2;

            var command = new DeleteAddressTypeCommand
            {
                Id = validId
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(4, _context.AddressTypes.Count());

        }
        [Fact]
        public async Task Handle_Given_Invalid_Id_Throws_NotFoundException()
        {
            // Arrange
            var invalidId = 100;
            
            var command = new DeleteAddressTypeCommand
            {
                Id = invalidId
            };

            // Act/Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));
        }
        [Fact]
        public async Task Handle_Given_AddressTypeId_For_Type_With_Addresses_Throws_DeleteFailureException()
        {
            // Arrange
            var validId = 1;

            var command = new DeleteAddressTypeCommand
            {
                Id = validId
            };

            // Act/Assert
            await Assert.ThrowsAsync<DeleteFailureException>(() => _sut.Handle(command, CancellationToken.None));
        }
        [Fact]
        public async Task Validate_Given_Valid_Id_Command_IsValid()
        {
            // Arrange
            var validId = 1;
            var command = new DeleteAddressTypeCommand
            {
                Id = validId
            };
            var validator = new DeleteAddressTypeCommandValidator();

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
            
        }
        [Fact]
        public async Task Validate_Given_Invalid_Id_Command_Is_Not_Valid()
        {
            // Arrange
            var command = new DeleteAddressTypeCommand();

            var validator = new DeleteAddressTypeCommandValidator();

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(result.Errors, x => x.PropertyName.Contains("Id"));
        }
    }
}
