using FluentValidation;
namespace CaseCore.Application.PersonTypes.Commands.DeletePersonType
{
    /// <summary>
    /// Implementation of <see cref="AbstractValidator{T}"/> used to validate a <see cref="DeletePersonTypeCommand"/>
    /// </summary>
    public class DeletePersonTypeCommandValidator : AbstractValidator<DeletePersonTypeCommand>
    {
        /// <summary>
        /// Creates a new instance of the validator
        /// </summary>
        public DeletePersonTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
