using CaseCore.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Types.PhoneNumberType"></see> entity
    /// </summary>
    public class PhoneNumberTypeConfiguration : IEntityTypeConfiguration<PhoneNumberType>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{PhoneNumberType}"/></param>
        public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
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
