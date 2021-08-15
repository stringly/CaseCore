using FluentValidation;

namespace CaseCore.Application.CaseAssignmentTypes.Commands.DeleteCaseAssignmentType
{
    /// <summary>
    /// Implementation of <see cref="AbstractValidator{T}"/> used to validate a <see cref="DeleteCaseAssignmentTypeCommand"/>
    /// </summary>
    public class DeleteCaseAssignmentTypeCommandValidator : AbstractValidator<DeleteCaseAssignmentTypeCommand>
    {
        /// <summary>
        /// Creates a new instance of the validator
        /// </summary>
        public DeleteCaseAssignmentTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
