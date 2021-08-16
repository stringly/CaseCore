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

namespace CaseCore.Application.CaseStatusTypes.Commands.UpsertCaseStatusType
{
    /// <summary>
    /// Implements <see cref="IRequestHandler{TRequest, TResponse}"></see> to handle a request to update/insert a Case Status Type.
    /// </summary>
    public class UpsertCaseStatusTypeCommandHandler : IRequestHandler<UpsertCaseStatusTypeCommand, int>
    {
        private readonly ICaseCoreDbContext _context;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        public UpsertCaseStatusTypeCommandHandler(ICaseCoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Handles a request to insert or update the <see cref="CaseStatusType"/>
        /// </summary>
        /// <param name="request">A <see cref="UpsertCaseStatusTypeCommand"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> containing the Integer Id of the upserted entity.</returns>    
        public async Task<int> Handle(UpsertCaseStatusTypeCommand request, CancellationToken cancellationToken)
        {
            CaseStatusType entity;
            if (request.Id.HasValue)
            {
                entity = await _context.CaseStatusTypes.FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(CaseStatusType), request.Id);
                }
                if (!String.IsNullOrWhiteSpace(request.Name) && entity.Name != request.Name)
                {
                    try
                    {
                        entity.UpdateName(request.Name);
                    }
                    catch (CaseStatusTypeArgumentException e)
                    {
                        throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure(e.ParamName, e.Message) });
                    }
                }
            }
            else
            {
                try
                {
                    entity = new CaseStatusType(request.Name);
                }
                catch (CaseStatusTypeArgumentException e)
                {
                    throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure(e.ParamName, e.Message) });
                }
                await _context.CaseStatusTypes.AddAsync(entity);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
