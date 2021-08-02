using CaseCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseCore.Domain.Entities
{
    public class AddressType : BaseEntity
    {
        private AddressType() { }

        private string _name;
        public string Name => _name;
    }
}
