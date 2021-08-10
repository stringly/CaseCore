using System;

namespace CaseCore.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Property)]
    public class IgnoreCodeCoverageAttribute : Attribute
    {

    }
}
