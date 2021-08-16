using MediatR;

namespace CaseCore.Application.PersonTypes.Queries.GetPersonTypeDetail
{
    /// <summary>
    /// Implementation of <see cref="IRequest"></see> that returns details of a <see cref="Domain.Types.PersonType"/> in a <see cref="PersonTypeDetailVm"></see>
    /// </summary>
    public class GetPersonTypeDetailQuery : IRequest<PersonTypeDetailVm>
    {
        /// <summary>
        /// The integer Id of the Person Type.
        /// </summary>
        public int Id { get; set; }
    }
}
