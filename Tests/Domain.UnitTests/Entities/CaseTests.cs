using CaseCore.Domain.Entities;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using System;
using Xunit;

namespace CaseCore.Domain.UnitTests.Entities
{
    public class CaseTests
    {
        // TODO: Add Case Entity Tests.
        /// <summary>
        /// Factory Method that creates a default Case for Test Methods.
        /// </summary>
        /// <returns>A <see cref="Case"/> object with default values.</returns>
        private Case CreateCase()
        {
            // Arrange
            string caseNumber = "PP12345600001111";

            return new Case(caseNumber);
        }

    }
}
