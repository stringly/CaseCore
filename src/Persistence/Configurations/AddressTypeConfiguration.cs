using CaseCore.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Types.AddressType"></see> entity
    /// </summary>
    public class AddressTypeConfiguration : IEntityTypeConfiguration<AddressType>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{AddressType}"/></param>
        public void Configure(EntityTypeBuilder<AddressType> builder)
        {
            builder.Property(p => p.Name)
                .HasField("_name")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Abbreviation)
                .HasField("_abbreviation")
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
