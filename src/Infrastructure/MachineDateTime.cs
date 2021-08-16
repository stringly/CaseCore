using CaseCore.Common;
using System;

namespace CaseCore.Infrastructure
{
    /// <summary>
    /// Implementation of <see cref="IDateTime"/>
    /// </summary>
    public class MachineDateTime : IDateTime
    {
        /// <summary>
        /// Returns the current DateTime.
        /// </summary>
        public DateTime Now => DateTime.Now;
        /// <summary>
        /// Returns the current year.
        /// </summary>
        public int CurrentYear => DateTime.Now.Year;
    }
}
