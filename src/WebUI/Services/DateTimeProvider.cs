using CaseCore.Common;
using System;

namespace CaseCore.WebUI.Services
{
    /// <summary>
    /// Implementation of <see cref="IDateTime"/> used to inject the system current time.
    /// </summary>
    public class DateTimeProvider : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
