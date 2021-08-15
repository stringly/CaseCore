using FluentValidation;

namespace CaseCore.Application.AddressTypes.Commands.DeleteAddressType
{
    /// <summary>
    /// Implementation of <see cref="AbstractValidator{T}"/> used to validate a <see cref="DeleteAddressTypeCommand"/>
    /// </summary>
    public class DeleteAddressTypeCommandValidator : AbstractValidator<DeleteAddressTypeCommand>
    {
        /// <summary>
        /// Creates a new instance of the validator
        /// </summary>
        public DeleteAddressTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
