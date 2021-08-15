using CaseCore.Persistence;
using System;

namespace CaseCore.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly CaseCoreDbContext _context;
        
        public CommandTestBase()
        {
            _context = CaseCoreDbContextFactory.Create();
        }
        public void Dispose()
        {
            CaseCoreDbContextFactory.Destroy(_context);
        }
    }
}
