using MediatR;

namespace CaseCore.Application.PhoneNumberTypes.Queries.GetPhoneNumberTypeList
{
    /// <summary>
    /// Implementation of <see cref="IRequest"></see> that returns a list of <see cref="Domain.Types.PhoneNumberType"></see> in an <see cref="PhoneNumberTypeListVm"/>
    /// </summary>
    public class GetPhoneNumberTypeListQuery : IRequest<PhoneNumberTypeListVm>
    {
        /// <summary>
        /// A string containing a sort order value. 
        /// </summary>
        /// <remarks>
        /// This field can sort the result list based on the following values:
        /// <list type="bullet">
        /// <item><description>Empty string: Phone Number Type list will be sorted by ascending Id.</description></item>
        /// <item><description>id_desc: Phone Number Type list will be sorted by descending Id.</description></item>
        /// <item><description>phoneNumberTypeName: Phone Number Type list will be sorted by Name in alphabetical order.</description></item>
        /// <item><description>phoneNumberTypeName_desc: Phone Number Type list will be sorted by Name in reverse alphabetical order.</description></item>       
        /// </list>
        /// </remarks>
        public string SortOrder { get; set; }
        /// <summary>
        /// An integer page number. Defaults to 1.
        /// </summary>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        /// An integer page size. Defaults to 1.
        /// </summary>
        public int PageSize { get; set; } = 25;
    }
}
