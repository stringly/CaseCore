using MediatR;


namespace CaseCore.Application.PersonTypes.Commands.DeletePersonType
{
    /// <summary>
    /// An implementation of <see cref="IRequest"></see> that handles a request to remove a <see cref="Domain.Types.PersonType"></see>
    /// </summary>
    public class DeletePersonTypeCommand : IRequest<bool>
    {
        /// <summary>
        /// The Id of the PersonType to remove.
        /// </summary>
        public int Id { get; set; }
    }
}
