using System.ComponentModel;

namespace CaseCore.Domain.Enums
{
    /// <summary>
    /// Enumeration that represents a gender.
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Male
        /// </summary>
        [Description("Male")]
        M,
        /// <summary>
        /// Female
        /// </summary>
        [Description("Female")]
        F,
        /// <summary>
        /// Non-binary
        /// </summary>
        [Description("Non-Binary")]
        N,
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
