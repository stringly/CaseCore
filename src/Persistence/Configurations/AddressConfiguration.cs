using CaseCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Entities.Address"></see> entity
    /// </summary>
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{Address}"/></param>
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.Street)
                .HasField("_street")
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(p => p.Suite)
                .HasField("_suite")
                .HasMaxLength(100);
            builder.Property(p => p.City)
                .HasField("_city")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.State)
                .HasField("_state")                
                .HasConversion<string>()
                .IsRequired();
            builder.Property(p => p.Zip)
                .HasField("_zip")
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(am => am.Beat)
                .HasField("_beat")
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(am => am.ReportingArea)
                .HasField("_reportingArea")
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(am => am.Longitude)
                .HasField("_longitude");
            builder.Property(am => am.Latitude)
                .HasField("_latitude");
            builder.HasOne(x => x.AddressType);

        }
    }
}
