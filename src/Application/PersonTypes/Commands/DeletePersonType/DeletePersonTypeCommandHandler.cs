using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Domain.Types;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.PersonTypes.Commands.DeletePersonType
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests to delete a Person Type
    ///</summary>
    public class DeletePersonTypeCommandHandler : IRequestHandler<DeletePersonTypeCommand, bool>
    {
        private readonly ICaseCoreDbContext _context;

        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        public DeletePersonTypeCommandHandler(ICaseCoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="request">A <see cref="DeletePersonTypeCommand"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>A boolean wrapped in a <see cref="Task"/></returns>
        public async Task<bool> Handle(DeletePersonTypeCommand request, CancellationToken cancellationToken)
        {
            var personsOfType = _context.Persons.Any(x => x.PersonTypeId == request.Id);
            if (personsOfType == true)
            {
                // There are Person entries of the PersonType to be deleted; deny delete.
                throw new DeleteFailureException(nameof(PersonType), request.Id, "Cannot delete Person Type: Persons exist of the type.");
            }
            PersonType toDelete = await _context.PersonTypes.FindAsync(request.Id);
            if (toDelete == null)
            {
                throw new NotFoundException(nameof(PersonType), request.Id);
            }
            try
            {
                _context.PersonTypes.Remove(toDelete);
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
