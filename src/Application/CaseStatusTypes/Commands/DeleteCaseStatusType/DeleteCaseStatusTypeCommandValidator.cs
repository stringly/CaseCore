using FluentValidation;

namespace CaseCore.Application.CaseStatusTypes.Commands.DeleteCaseStatusType
{
    /// <summary>
    /// Implementation of <see cref="AbstractValidator{T}"/> used to validate a <see cref="DeleteCaseStatusTypeCommand"/>
    /// </summary>
    public class DeleteCaseStatusTypeCommandValidator : AbstractValidator<DeleteCaseStatusTypeCommand>
    {
        /// <summary>
        /// Creates a new instance of the validator
        /// </summary>
        public DeleteCaseStatusTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
