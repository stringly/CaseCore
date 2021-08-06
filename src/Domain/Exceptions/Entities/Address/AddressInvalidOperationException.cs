using System;
using System.Collections.Generic;
using System.Text;

namespace CaseCore.Domain.Exceptions.Entities.Address
{
    public class AddressInvalidOperationException : InvalidOperationException
    {
        public AddressInvalidOperationException(string message) : base(message) { }
    }
}
