using MediatR;

namespace CaseCore.Application.AddressTypes.Queries.GetAddressTypeDetail
{
    /// <summary>
    /// Implementation of <see cref="IRequest"></see> that returns details of a <see cref="Domain.Types.AddressType"/> in a <see cref="AddressTypeDetailVm"></see>
    /// </summary>
    public class GetAddressTypeDetailQuery : IRequest<AddressTypeDetailVm>
    {
        /// <summary>
        /// The integer Id of the Address Type.
        /// </summary>
        public int Id { get; set; }
    }
}
