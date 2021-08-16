using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Domain.Exceptions.Types;
using CaseCore.Domain.Types;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.PhoneNumberTypes.Commands.UpsertPhoneNumberType
{
    /// <summary>
    /// Implements <see cref="IRequestHandler{TRequest, TResponse}"></see> to handle a request to update/insert a Phone Number Type.
    /// </summary>
    public class UpsertPhoneNumberTypeCommandHandler : IRequestHandler<UpsertPhoneNumberTypeCommand, int>
    {
        private readonly ICaseCoreDbContext _context;

        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        public UpsertPhoneNumberTypeCommandHandler(ICaseCoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Handles a request to insert or update the <see cref="PhoneNumberType"/>
        /// </summary>
        /// <param name="request">The command.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A <see cref="Task"/> containing the Integer Id of the upserted entity.</returns>        
        public async Task<int> Handle(UpsertPhoneNumberTypeCommand request, CancellationToken cancellationToken)
        {
            PhoneNumberType entity;
            if (request.Id.HasValue)
            {
                entity = await _context.PhoneNumberTypes.FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(PhoneNumberType), request.Id);
                }
                if (!String.IsNullOrWhiteSpace(request.Name) && entity.Name != request.Name)
                {
                    try
                    {
                        entity.UpdateFullName(request.Name);
                    }
                    catch (PhoneNumberTypeArgumentException e)
                    {
                        throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure(e.ParamName, e.Message) });
                    }
                }
                if (!String.IsNullOrWhiteSpace(request.Abbreviation) && entity.Abbreviation != request.Abbreviation)
                {
                    try
                    {
                        entity.UpdateAbbreviation(request.Abbreviation);
                    }
                    catch (AddressTypeArgumentException e)
                    {
                        throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure(e.ParamName, e.Message) });
                    }
                }
            }
            else
            {
                try
                {
                    entity = new PhoneNumberType(request.Name, request.Abbreviation);
                }
                catch (AddressTypeArgumentException e)
                {
                    throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure(e.ParamName, e.Message) });
                }
                await _context.PhoneNumberTypes.AddAsync(entity);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
