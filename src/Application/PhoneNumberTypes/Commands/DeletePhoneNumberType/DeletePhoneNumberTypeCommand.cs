using MediatR;

namespace CaseCore.Application.PhoneNumberTypes.Commands.DeletePhoneNumberType
{
    /// <summary>
    /// An implementation of <see cref="IRequest"></see> that handles a request to remove a <see cref="Domain.Types.PhoneNumberType"></see>
    /// </summary>
    public class DeletePhoneNumberTypeCommand : IRequest<bool>
    {
        /// <summary>
        /// The Id of the Phone Number Type to remove.
        /// </summary>
        public int Id { get; set; }
    }
}
