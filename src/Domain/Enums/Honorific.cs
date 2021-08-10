using System.ComponentModel;

namespace CaseCore.Domain.Enums
{
    /// <summary>
    /// Enumeration that represents a formal title prefix for a person.
    /// </summary>
    public enum Honorific
    {
        /// <summary>
        /// Mr.
        /// </summary>
        [Description("Mr.")]
        Mr,
        /// <summary>
        /// Ms.
        /// </summary>
        [Description("Ms.")]
        Ms,
        /// <summary>
        /// Mrs.
        /// </summary>
        [Description("Mrs.")]
        Mrs,
        /// <summary>
        /// Dr.
        /// </summary>
        [Description("Dr.")]
        Dr,
        /// <summary>
        /// Mx.
        /// </summary>
        [Description("Mx.")]
        Mx,
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("")]
        Unk
    }
}
