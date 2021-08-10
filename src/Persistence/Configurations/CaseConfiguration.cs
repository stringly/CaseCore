using CaseCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.Property(c => c.CaseNumber)
                .HasField("_caseNumber")                
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.OccurredBetweenStartDate)
                .HasField("_occurredBetweenStartDate");
            builder.Property(c => c.OccurredBetweenEndDate)
                .HasField("_occurredBetweenEndDate");
            builder.Property(c => c.OccurredOnExactDate)
                .HasField("_occurredOnExactDate");
            builder.Property(c => c.ReportedOnDate)
                .HasField("_reportedOnDate")
                .IsRequired();
            var navigation1 = builder.Metadata.FindNavigation(nameof(Case.CaseOffenses));
            navigation1.SetPropertyAccessMode(PropertyAccessMode.Field);
            var navigation2 = builder.Metadata.FindNavigation(nameof(Case.Persons));
            navigation2.SetPropertyAccessMode(PropertyAccessMode.Field);
            var navigation3 = builder.Metadata.FindNavigation(nameof(Case.Addresses));
            navigation3.SetPropertyAccessMode(PropertyAccessMode.Field);
            var navigation4 = builder.Metadata.FindNavigation(nameof(Case.CaseStatuses));
            navigation4.SetPropertyAccessMode(PropertyAccessMode.Field);
            var navigation5 = builder.Metadata.FindNavigation(nameof(Case.CaseAssignments));
            navigation5.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
