using FluentValidation;

namespace CaseCore.Application.PhoneNumberTypes.Commands.DeletePhoneNumberType
{
    /// <summary>
    /// Implementation of <see cref="AbstractValidator{T}"/> used to validate a <see cref="DeletePhoneNumberTypeCommand"/>
    /// </summary>
    public class DeletePhoneNumberTypeCommandValidator : AbstractValidator<DeletePhoneNumberTypeCommand>
    {
        /// <summary>
        /// Creates a new instance of the validator
        /// </summary>
        public DeletePhoneNumberTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
