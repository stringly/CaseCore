using CaseCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="CaseStatus"></see> entity
    /// </summary>
    public class CaseStatusConfiguration : IEntityTypeConfiguration<CaseStatus>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{CaseStatus}"/></param>
        public void Configure(EntityTypeBuilder<CaseStatus> builder)
        {
            builder.HasOne(x => x.Case)
                .WithMany(x => x.CaseStatuses)
                .IsRequired();
            builder.HasOne(x => x.CaseStatusType);
            builder.Property(x => x.StatusDate)
                .HasField("_statusDate")
                .IsRequired();
            builder.Property(x => x.Remarks)
                .HasField("_remarks")
                .HasMaxLength(1000);
        }
    }
}
