using CaseCore.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Types.OffenseType"></see> entity
    /// </summary>
    public class OffenseTypeConfiguration : IEntityTypeConfiguration<OffenseType>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{OffenseType}"/></param>
        public void Configure(EntityTypeBuilder<OffenseType> builder)
        {
            builder.Property(e => e.Name)
                .HasField("_name")
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Abbreviation)
                .HasField("_abbreviation")
                .IsRequired()
                .HasMaxLength(5);
        }
    }
}
