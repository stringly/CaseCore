using MediatR;

namespace CaseCore.Application.CaseStatusTypes.Commands.DeleteCaseStatusType
{
    /// <summary>
    /// An implementation of <see cref="IRequest"></see> that handles a request to remove a <see cref="Domain.Types.CaseAssignmentType"></see>
    /// </summary>
    public class DeleteCaseStatusTypeCommand : IRequest<bool>
    {
        /// <summary>
        /// The Id of the CaseStatusType to remove.
        /// </summary>
        public int Id { get; set; }
    }
}
