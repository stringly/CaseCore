using System;
using System.Collections.Generic;
using System.Text;

namespace CaseCore.Application.PersonTypes.Queries.GetPersonTypeDetail
{
    /// <summary>
    /// Viewmodel class used in the GetPersonTypeDetail Query
    /// </summary>
    public class PersonTypeDetailVm
    {
        /// <summary>
        /// The Person Type
        /// </summary>
        public PersonTypeDto PersonType { get; set; }
        public object CaseStatusType { get; set; }
    }
}
