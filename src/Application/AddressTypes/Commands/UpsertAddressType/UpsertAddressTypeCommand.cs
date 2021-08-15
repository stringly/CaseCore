using CaseCore.Domain.Types;
using MediatR;

namespace CaseCore.Application.AddressTypes.Commands.UpsertAddressType
{
    /// <summary>
    /// Implementation of <see cref="IRequest"></see> that creates/updates a <see cref="AddressType"></see>
    /// </summary>
    public class UpsertAddressTypeCommand : IRequest<int>
    {
        /// <summary>
        /// The Id of the <see cref="AddressType"/> being upserted.
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// A string containing the Name of the <see cref="AddressType"/>
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A string containing the Abbreviation of the <see cref="AddressType"/>
        /// </summary>
        public string Abbreviation { get; set; }
    }
}
