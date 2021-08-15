using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Domain.Types;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.CaseAssignmentTypes.Commands.DeleteCaseAssignmentType
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests to delete a Case Assignment Type
    /// </summary>
    public class DeleteCaseAssignmentTypeCommandHandler : IRequestHandler<DeleteCaseAssignmentTypeCommand, bool>
    {
        private readonly ICaseCoreDbContext _context;

        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        public DeleteCaseAssignmentTypeCommandHandler(ICaseCoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="request">A <see cref="DeleteCaseAssignmentTypeCommand"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>A boolean wrapped in a <see cref="Task"/></returns>
        public async Task<bool> Handle(DeleteCaseAssignmentTypeCommand request, CancellationToken cancellationToken)
        {
            var assignmentsOfType = _context.CaseAssignments.Any(x => x.CaseAssignmentTypeId == request.Id);
            if (assignmentsOfType == true)
            {
                // There are Assignment entries of the CaseAssignmentType to be deleted; deny delete.
                throw new DeleteFailureException(nameof(CaseAssignmentType), request.Id, "Cannot delete Case Assignment Type: Case Assignments exist of the type.");
            }
            CaseAssignmentType toDelete = await _context.CaseAssignmentTypes.FindAsync(request.Id);
            if (toDelete == null)
            {
                throw new NotFoundException(nameof(CaseAssignmentType), request.Id);
            }
            try
            {
                _context.CaseAssignmentTypes.Remove(toDelete);
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
