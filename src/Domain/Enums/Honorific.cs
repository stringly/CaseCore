using System.ComponentModel;

namespace CaseCore.Domain.Enums
{
    public enum Honorific
    {
        [Description("Mr.")]
        Mr,
        [Description("Ms.")]
        Ms,
        [Description("Mrs.")]
        Mrs,
        [Description("Dr.")]
        Dr,
        [Description("Mx.")]
        Mx
    }
}
