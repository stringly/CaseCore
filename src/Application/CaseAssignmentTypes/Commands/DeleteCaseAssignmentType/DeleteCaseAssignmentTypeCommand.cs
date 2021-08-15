using MediatR;

namespace CaseCore.Application.CaseAssignmentTypes.Commands.DeleteCaseAssignmentType
{
    /// <summary>
    /// An implementation of <see cref="IRequest"></see> that handles a request to remove a <see cref="Domain.Types.CaseAssignmentType"></see>
    /// </summary>
    public class DeleteCaseAssignmentTypeCommand : IRequest<bool>
    {
        /// <summary>
        /// The Id of the CaseAssignmentType to remove.
        /// </summary>
        public int Id { get; set; }
    }
}
