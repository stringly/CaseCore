using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Domain.Types;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.AddressTypes.Commands.DeleteAddressType
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests to delete an Address Type
    /// </summary>
    public class DeleteAddressTypeCommandHandler : IRequestHandler<DeleteAddressTypeCommand,bool>
    {
        private readonly ICaseCoreDbContext _context;

        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        public DeleteAddressTypeCommandHandler(ICaseCoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="request">A <see cref="DeleteAddressTypeCommand"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>A boolean wrapped in a <see cref="Task"/></returns>
        public async Task<bool> Handle(DeleteAddressTypeCommand request, CancellationToken cancellationToken)
        {
            var addressesOfType = _context.Addresses.Any(x => x.AddressTypeId == request.Id);
            if (addressesOfType == true)
            {
                // There are Address entries of the Address Type to be deleted; deny delete.
                throw new DeleteFailureException(nameof(AddressType), request.Id, "Cannot delete Address Type: Addresses exist of the type.");
            }
            AddressType toDelete = await _context.AddressTypes.FindAsync(request.Id);
            if (toDelete == null)
            {
                throw new NotFoundException(nameof(AddressType), request.Id);
            }
            try
            {
                _context.AddressTypes.Remove(toDelete);
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
