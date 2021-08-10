using CaseCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Entities.CaseOffense"></see> entity
    /// </summary>
    public class CaseOffenseConfiguration : IEntityTypeConfiguration<CaseOffense>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{CaseOffense}"/></param>
        public void Configure(EntityTypeBuilder<CaseOffense> builder)
        {
            builder.HasOne(x => x.Case)
                .WithMany(x => x.CaseOffenses)
                .IsRequired();
            builder.HasOne(x => x.OffenseType);
        }
    }
}
