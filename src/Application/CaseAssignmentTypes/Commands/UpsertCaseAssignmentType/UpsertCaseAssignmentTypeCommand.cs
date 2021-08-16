using CaseCore.Domain.Types;
using MediatR;

namespace CaseCore.Application.CaseAssignmentTypes.Commands.UpsertCaseAssignmentType
{
    /// <summary>
    /// Implementation of <see cref="IRequest"></see> that creates/updates a <see cref="CaseAssignmentType"></see>
    /// </summary>
    public class UpsertCaseAssignmentTypeCommand : IRequest<int>
    {
        /// <summary>
        /// The Id of the <see cref="CaseAssignmentType"/> being upserted.
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// A string containing the Name of the <see cref="CaseAssignmentType"/>
        /// </summary>
        public string Name { get; set; }
    }
}
