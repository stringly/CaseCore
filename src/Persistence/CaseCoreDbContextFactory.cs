using Microsoft.EntityFrameworkCore;

namespace CaseCore.Persistence
{
    /// <summary>
    /// Implemention of <see cref="DesignTimeDbContextFactoryBase{TContext}"></see>
    /// </summary>
    public class CaseCoreDbContextFactory : DesignTimeDbContextFactoryBase<CaseCoreDbContext>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="CaseCoreDbContext"></see>
        /// </summary>
        /// <param name="options">A <see cref="DbContextOptions"></see> object.</param>
        /// <returns></returns>
        protected override CaseCoreDbContext CreateNewInstance(DbContextOptions<CaseCoreDbContext> options)
        {
            return new CaseCoreDbContext(options);
        }
    }
}
