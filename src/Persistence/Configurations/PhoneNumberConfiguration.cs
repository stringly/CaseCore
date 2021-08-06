using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CaseCore.Domain.Entities;
using CaseCore.Domain.Types;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Entities.PhoneNumber"></see> entity
    /// </summary>
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{PersonPhone}"/></param>
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.Property(e => e.Number)
                .HasField("_number")
                .HasMaxLength(10)
                .IsRequired();
            builder.HasOne(typeof(PhoneNumberType), "PhoneNumberType");

        }
    }
}
