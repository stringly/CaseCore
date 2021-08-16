using CaseCore.Domain.Types;
using MediatR;

namespace CaseCore.Application.PhoneNumberTypes.Commands.UpsertPhoneNumberType
{
    /// <summary>
    /// Implementation of <see cref="IRequest"></see> that creates/updates a <see cref="PhoneNumberType"></see>
    /// </summary>
    public class UpsertPhoneNumberTypeCommand : IRequest<int>
    {
        /// <summary>
        /// The Id of the <see cref="PhoneNumberType"/> being upserted.
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// A string containing the Name of the <see cref="PhoneNumberType"/>
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A string containing the Abbreviation of the <see cref="PhoneNumberType"/>
        /// </summary>
        public string Abbreviation { get; set; }
    }
}
