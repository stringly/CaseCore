using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Domain.Types;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.CaseStatusTypes.Commands.DeleteCaseStatusType
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests to delete a Case Status Type
    /// </summary>
    public class DeleteCaseStatusTypeCommandHandler : IRequestHandler<DeleteCaseStatusTypeCommand, bool>
    {
        private readonly ICaseCoreDbContext _context;

        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        public DeleteCaseStatusTypeCommandHandler(ICaseCoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="request">A <see cref="DeleteCaseStatusTypeCommand"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>A boolean wrapped in a <see cref="Task"/></returns>
        public async Task<bool> Handle(DeleteCaseStatusTypeCommand request, CancellationToken cancellationToken)
        {
            var statusesOfType = _context.CaseStatuses.Any(x => x.CaseStatusTypeId == request.Id);
            if (statusesOfType == true)
            {
                // There are Assignment entries of the CaseStatusType to be deleted; deny delete.
                throw new DeleteFailureException(nameof(CaseStatusType), request.Id, "Cannot delete Case Status Type: Case Statuses exist of the type.");
            }
            CaseStatusType toDelete = await _context.CaseStatusTypes.FindAsync(request.Id);
            if (toDelete == null)
            {
                throw new NotFoundException(nameof(CaseStatusType), request.Id);
            }
            try
            {
                _context.CaseStatusTypes.Remove(toDelete);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }
        }
    }
}
