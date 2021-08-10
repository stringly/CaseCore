using System.ComponentModel;

namespace CaseCore.Domain.Enums
{
    /// <summary>
    /// Enumeration that represents a person's race.
    /// </summary>
    public enum Race
    {
        /// <summary>
        /// White/Caucasian
        /// </summary>
        [Description("White")]
        W,
        /// <summary>
        /// Black
        /// </summary>
        [Description("Black")]
        B,
        /// <summary>
        /// Hispanic
        /// </summary>
        [Description("Hispanic")]
        H,
        /// <summary>
        /// Asian
        /// </summary>
        [Description("Asian")]
        A,
        /// <summary>
        /// Other
        /// </summary>
        [Description("Other")]
        O,
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        U
    }
}
