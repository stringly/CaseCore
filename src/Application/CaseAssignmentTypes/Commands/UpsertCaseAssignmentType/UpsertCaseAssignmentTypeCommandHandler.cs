using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.CaseAssignmentTypes.Commands.UpsertCaseAssignmentType
{
    /// <summary>
    /// Implements <see cref="IRequestHandler{TRequest, TResponse}"></see> to handle a request to update/insert a Case Assignment Type.
    /// </summary>
    public class UpsertCaseAssignmentTypeCommandHandler : IRequestHandler<UpsertCaseAssignmentTypeCommand, int>
    {
        private readonly ICaseCoreDbContext _context;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        public UpsertCaseAssignmentTypeCommandHandler(ICaseCoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Handles a request to insert or update the <see cref="CaseAssignmentType"/>
        /// </summary>
        /// <param name="request">A <see cref="UpsertCaseAssignmentTypeCommand"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> containing the Integer Id of the upserted entity.</returns>    
        public async Task<int> Handle(UpsertCaseAssignmentTypeCommand request, CancellationToken cancellationToken)
        {
            CaseAssignmentType entity;
            if (request.Id.HasValue)
            {
                entity = await _context.CaseAssignmentTypes.FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(CaseAssignmentType), request.Id);
                }
                if (!String.IsNullOrWhiteSpace(request.Name) && entity.Name != request.Name)
                {
                    try
                    {
                        entity.UpdateName(request.Name);
                    }
                    catch (CaseAssignmentArgumentException e)
                    {
                        throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure(e.ParamName, e.Message)});
                    }
                }
            }
            else
            {
                try
                {
                    entity = new CaseAssignmentType(request.Name);
                }
                catch (CaseAssignmentArgumentException e)
                {
                    throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure(e.ParamName, e.Message)});
                }
                await _context.CaseAssignmentTypes.AddAsync(entity);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
