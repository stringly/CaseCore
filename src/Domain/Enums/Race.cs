using System.ComponentModel;

namespace CaseCore.Domain.Enums
{
    public enum Race
    {
        [Description("White")]
        W,
        [Description("Black")]
        B,
        [Description("Hispanic")]
        H,
        [Description("Asian")]
        A,
        [Description("Other")]
        O,
        [Description("Unknown")]
        U
    }
}
