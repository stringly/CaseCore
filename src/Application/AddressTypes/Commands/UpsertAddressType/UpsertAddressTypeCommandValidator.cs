using CaseCore.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Linq;

namespace CaseCore.Application.AddressTypes.Commands.UpsertAddressType
{
    /// <summary>
    /// Implementation of <seealso cref="AbstractValidator{T}"/> used to validate data in the <see cref="UpsertAddressTypeCommand"></see>
    /// </summary>
    public class UpsertAddressTypeCommandValidator : AbstractValidator<UpsertAddressTypeCommand>
    {
        private readonly ICaseCoreDbContext _context;
        /// <summary>
        /// Creates a new instance of the validator
        /// </summary>
        /// <param name="context"></param>
        public UpsertAddressTypeCommandValidator(ICaseCoreDbContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(25).WithMessage("Maximum length is 25 characters.")
                .MinimumLength(2).WithMessage("Minimum length is 2 characters.")
                .Must((obj, name) => IsNameUnique(obj.Name, obj.Id)).WithMessage("The Name is already in use by another Address Type.")
                .When(x => x.Id == null);            
            RuleFor(x => x.Abbreviation)
                .NotEmpty()
                .MaximumLength(5).WithMessage("Maximum length is 5 characters.")
                .MinimumLength(1).WithMessage("Minimum length is 1 character.")
                .Must((obj, name) => IsAbbreviationUnique(obj.Abbreviation, obj.Id)).WithMessage("The Abbreviation is already in use by another Address Type.")
                .When(x => x.Id == null);
            RuleFor(x => x.Name)
                .NotEmpty()
                .When(x => x.Id != null && x.Abbreviation == string.Empty)
                .WithMessage("Either Name or Abbreviation must be present when editing an AddressType.");
            RuleFor(x => x.Name)
                .Must((obj, name) => IsNameUnique(obj.Name, obj.Id))
                .WithMessage($"The Name is already in use by another Address Type.")
                .When(x => x.Id != null);
            RuleFor(x => x.Abbreviation)                
                .Must((obj, name) => IsAbbreviationUnique(obj.Abbreviation, obj.Id))
                .WithMessage($"The Abbreviation is already in use by another Address Type.")
                .When(x => x.Id != null);
            RuleFor(x => x.Abbreviation)
                .NotEmpty()
                .When(x => x.Id != null && x.Name == string.Empty)
                .WithMessage("Either Name or Abbreviation must be present when editing an AddressType.");
        }

        private bool IsNameUnique(string name, int? id)
        {
            if (id == null)
            {
                if (_context.AddressTypes.Any(x => x.Name == name))
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
                if (_context.AddressTypes.Any(x => x.Name == name && x.Id != Convert.ToInt32(id)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        private bool IsAbbreviationUnique(string name, int? id)
        {
            if (id == null)
            {
                if (_context.AddressTypes.Any(x => x.Abbreviation == name))
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
                if (_context.AddressTypes.Any(x => x.Abbreviation == name && x.Id != Convert.ToInt32(id)))
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
