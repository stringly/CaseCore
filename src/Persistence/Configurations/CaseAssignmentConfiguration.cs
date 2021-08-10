using CaseCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="CaseAssignment"></see> entity
    /// </summary>
    public class CaseAssignmentConfiguration : IEntityTypeConfiguration<CaseAssignment>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{CaseAssignment}"/></param>
        public void Configure(EntityTypeBuilder<CaseAssignment> builder)
        {
            builder.HasOne(x => x.Case)
                .WithMany(x => x.CaseAssignments)
                .IsRequired();
            builder.HasOne(x => x.CaseAssignmentType);
            builder.Property(x => x.AssignedToName)
                .HasField("_assignedToName")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.AssignmentDate)
                .HasField("_assignmentDate")
                .IsRequired();
            builder.Property(x => x.Remarks)
                .HasField("_remarks")
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
