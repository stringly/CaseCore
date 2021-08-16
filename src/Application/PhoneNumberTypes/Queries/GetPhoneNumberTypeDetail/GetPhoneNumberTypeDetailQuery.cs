using MediatR;

namespace CaseCore.Application.PhoneNumberTypes.Queries.GetPhoneNumberTypeDetail
{
    /// <summary>
    /// Implementation of <see cref="IRequest"></see> that returns details of a <see cref="Domain.Types.PhoneNumberType"/> in a <see cref="PhoneNumberTypeDetailVm"></see>
    /// </summary>
    public class GetPhoneNumberTypeDetailQuery : IRequest<PhoneNumberTypeDetailVm>
    {
        /// <summary>
        /// The integer Id of the Phone Number Type.
        /// </summary>
        public int Id { get; set; }
    }
}
