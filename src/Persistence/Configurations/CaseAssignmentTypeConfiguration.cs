using CaseCore.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Types.CaseAssignmentType"></see> entity
    /// </summary>
    public class CaseAssignmentTypeConfiguration : IEntityTypeConfiguration<CaseAssignmentType>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{CaseAssignmentType}"/></param>
        public void Configure(EntityTypeBuilder<CaseAssignmentType> builder)
        {
            builder.Property(e => e.Name)
                .HasField("_name")
                .IsRequired()
                .HasMaxLength(200);

        }
    }
}
