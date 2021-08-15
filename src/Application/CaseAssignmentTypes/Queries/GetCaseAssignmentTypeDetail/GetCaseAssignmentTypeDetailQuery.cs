using MediatR;

namespace CaseCore.Application.CaseAssignmentTypes.Queries.GetCaseAssignmentTypeDetail
{
    /// <summary>
    /// Implementation of <see cref="IRequest"></see> that returns details of a <see cref="Domain.Types.CaseAssignmentType"/> in a <see cref="CaseAssignmentTypeDetailVm"></see>
    /// </summary>
    public class GetCaseAssignmentTypeDetailQuery : IRequest<CaseAssignmentTypeDetailVm>
    {
        /// <summary>
        /// The integer Id of the Case Assignment Type.
        /// </summary>
        public int Id { get; set; }
    }
}
