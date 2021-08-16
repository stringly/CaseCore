using CaseCore.Application.Common.Models;
using System.Collections.Generic;

namespace CaseCore.Application.CaseAssignmentTypes.Queries.GetCaseAssignmentTypeList
{
    /// <summary>
    /// Viewmodel class used in the GetCaseAssignmentTypeList Query
    /// </summary>
    public class CaseAssignmentTypeListVm
    {
        /// <summary>
        /// A list of <see cref="CaseAssignmentTypeDto"/>
        /// </summary>
        public IEnumerable<CaseAssignmentTypeDto> CaseAssignmentTypes { get; set; }
        /// <summary>
        /// An instance of <see cref="Common.Models.PagingInfo"/> used to page the result list.
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
        /// <summary>
        /// String containing the current sorting applied to the list
        /// </summary>
        public string CurrentSort { get; set; }
        /// <summary>
        /// A string containing a sorting tag for the Name field.
        /// </summary>
        public string NameSort { get; set; }
        /// <summary>
        /// A string containing a sorting tag for the Id field.
        /// </summary>
        public string IdSort { get; set; }
    }
}
