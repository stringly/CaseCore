using MediatR;

namespace CaseCore.Application.AddressTypes.Queries.GetAddressTypeList
{
    /// <summary>
    /// Implementation of <see cref="IRequest"></see> that returns a list of <see cref="Domain.Types.AddressType"></see> in an <see cref="AddressTypeListVm"/>
    /// </summary>
    public class GetAddressTypeListQuery : IRequest<AddressTypeListVm>
    {
        /// <summary>
        /// A string containing a sort order value. 
        /// </summary>
        /// <remarks>
        /// This field can sort the result list based on the following values:
        /// <list type="bullet">
        /// <item><description>Empty string: AddressType list will be sorted by ascending Id.</description></item>
        /// <item><description>id_desc: AddressType list will be sorted by descending Id.</description></item>
        /// <item><description>addressTypeName: AddressType list will be sorted by Name in alphabetical order.</description></item>
        /// <item><description>addressTypeName_desc: AddressType list will be sorted by Name in reverse alphabetical order.</description></item>       
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
