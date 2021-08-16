using MediatR;
using CaseCore.Domain.Types;

namespace CaseCore.Application.CaseStatusTypes.Commands.UpsertCaseStatusType
{
    /// <summary>
    /// Implementation of <see cref="IRequest"></see> that creates/updates a <see cref="CaseStatusType"></see>
    /// </summary>
    public class UpsertCaseStatusTypeCommand : IRequest<int>
    {
        /// <summary>
        /// The Id of the <see cref="CaseStatusType"/> being upserted.
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// A string containing the Name of the <see cref="CaseStatusType"/>
        /// </summary>
        public string Name { get; set; }
    }
}
