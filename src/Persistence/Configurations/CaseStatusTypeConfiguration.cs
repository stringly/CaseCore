using CaseCore.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Types.CaseStatusType"></see> entity
    /// </summary>
    public class CaseStatusTypeConfiguration : IEntityTypeConfiguration<CaseStatusType>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{CaseStatusType}"/></param>
        public void Configure(EntityTypeBuilder<CaseStatusType> builder)
        {
            builder.Property(e => e.Name)
                .HasField("_name")
                .IsRequired()
                .HasMaxLength(25);

        }
    }
}
