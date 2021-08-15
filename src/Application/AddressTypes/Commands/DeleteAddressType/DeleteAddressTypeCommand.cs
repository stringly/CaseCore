using MediatR;

namespace CaseCore.Application.AddressTypes.Commands.DeleteAddressType
{
    /// <summary>
    /// An implementation of <see cref="IRequest"></see> that handles a request to remove a <see cref="Domain.Types.AddressType"></see>
    /// </summary>
    public class DeleteAddressTypeCommand : IRequest<bool>
    {
        /// <summary>
        /// The Id of the AddressType to remove.
        /// </summary>
        public int Id { get; set; }
    }
}
