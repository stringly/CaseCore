using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CaseCore.Domain.Entities;
using CaseCore.Domain.Types;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Entities.Case"></see> entity
    /// </summary>
    public class CaseConfiguration : IEntityTypeConfiguration<Case>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{Case}"/></param>
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            builder.Property(p => p.CaseNumber)
                .HasField("_caseNumber")
                .HasMaxLength(100)
                .IsRequired();
            var navigation1 = builder.Metadata.FindNavigation(nameof(Case.Persons));
            navigation1.SetPropertyAccessMode(PropertyAccessMode.Field);
            var navigation2 = builder.Metadata.FindNavigation(nameof(Case.Addresses));
            navigation2.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
