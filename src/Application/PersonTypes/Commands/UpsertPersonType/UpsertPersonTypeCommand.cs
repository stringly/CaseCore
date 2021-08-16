using CaseCore.Domain.Types;
using MediatR;

namespace CaseCore.Application.PersonTypes.Commands.UpsertPersonType
{
    /// <summary>
    /// Implementation of <see cref="IRequest"></see> that creates/updates a <see cref="PersonType"></see>
    /// </summary>
    public class UpsertPersonTypeCommand : IRequest<int>
    {
        /// <summary>
        /// The Id of the <see cref="PersonType"/> being upserted.
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// A string containing the Name of the <see cref="PersonType"/>
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A string containing the Abbreviation of the <see cref="PersonType"/>
        /// </summary>
        public string Abbreviation { get; set; }
    }
}
