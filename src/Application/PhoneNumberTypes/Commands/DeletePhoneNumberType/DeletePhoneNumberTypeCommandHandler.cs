using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Domain.Types;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.PhoneNumberTypes.Commands.DeletePhoneNumberType
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests to delete an Address Type
    /// </summary>
    public class DeletePhoneNumberTypeCommandHandler : IRequestHandler<DeletePhoneNumberTypeCommand, bool>
    {
        private readonly ICaseCoreDbContext _context;

        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        public DeletePhoneNumberTypeCommandHandler(ICaseCoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="request">A <see cref="DeletePhoneNumberTypeCommand"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>A boolean wrapped in a <see cref="Task"/></returns>
        public async Task<bool> Handle(DeletePhoneNumberTypeCommand request, CancellationToken cancellationToken)
        {
            var phoneNumbersOfType = _context.PhoneNumbers.Any(x => x.PhoneNumberTypeId == request.Id);
            if (phoneNumbersOfType == true)
            {
                // There are Address entries of the Address Type to be deleted; deny delete.
                throw new DeleteFailureException(nameof(PhoneNumberType), request.Id, "Cannot delete Phone Number Type: Phone Numbers exist of the type.");
            }
            PhoneNumberType toDelete = await _context.PhoneNumberTypes.FindAsync(request.Id);
            if (toDelete == null)
            {
                throw new NotFoundException(nameof(PhoneNumberType), request.Id);
            }
            try
            {
                _context.PhoneNumberTypes.Remove(toDelete);
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
