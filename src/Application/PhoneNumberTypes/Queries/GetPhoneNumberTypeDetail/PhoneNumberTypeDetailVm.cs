using System;
using System.Collections.Generic;
using System.Text;

namespace CaseCore.Application.PhoneNumberTypes.Queries.GetPhoneNumberTypeDetail
{
    /// <summary>
    /// Viewmodel used in the <see cref="GetPhoneNumberTypeDetailQuery"/>
    /// </summary>
    public class PhoneNumberTypeDetailVm
    {
        /// <summary>
        /// The Phone Number Type
        /// </summary>
        public PhoneNumberTypeDto PhoneNumberType { get; set; }
        public object PersonType { get; set; }
    }
}
