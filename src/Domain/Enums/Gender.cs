using System.ComponentModel;

namespace CaseCore.Domain.Enums
{
    public enum Gender
    {
        [Description("Male")]
        M,
        [Description("Female")]
        F,
        [Description("Non-Binary")]
        N,
        [Description("Other")]
        O
    }
}
