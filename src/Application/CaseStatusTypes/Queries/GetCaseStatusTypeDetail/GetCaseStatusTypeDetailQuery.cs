using MediatR;

namespace CaseCore.Application.CaseStatusTypes.Queries.GetCaseStatusTypeDetail
{
    /// <summary>
    /// Implementation of <see cref="IRequest"></see> that returns details of a <see cref="Domain.Types.CaseAssignmentType"/> in a <see cref="CaseStatusTypeDetailVm"></see>
    /// </summary>
    public class GetCaseStatusTypeDetailQuery : IRequest<CaseStatusTypeDetailVm>
    {
        /// <summary>
        /// The integer Id of the Case Assignment Type.
        /// </summary>
        public int Id { get; set; }
    }
}
