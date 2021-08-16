using CaseCore.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Linq;

namespace CaseCore.Application.CaseStatusTypes.Commands.UpsertCaseStatusType
{
    /// <summary>
    /// Implementation of <seealso cref="AbstractValidator{T}"/> used to validate data in the <see cref="UpsertCaseStatusTypeCommand"></see>
    /// </summary>
    public class UpsertCaseStatusTypeCommandValidator : AbstractValidator<UpsertCaseStatusTypeCommand>
    {
        private readonly ICaseCoreDbContext _context;
        /// <summary>
        /// Creates a new instance of the validator.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        public UpsertCaseStatusTypeCommandValidator(ICaseCoreDbContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(25).WithMessage("Maximum length is 25 characters.")
                .MinimumLength(2).WithMessage("Minimum length is 2 characters.")
                .Must((obj, name) => IsNameUnique(obj.Name, obj.Id)).WithMessage("The Name is already in use by another Case Status Type.");
        }

        private bool IsNameUnique(string name, int? id)
        {
            if (id == null)
            {
                if (_context.CaseStatusTypes.Any(x => x.Name == name))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (_context.CaseStatusTypes.Any(x => x.Name == name && x.Id != Convert.ToInt32(id)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
