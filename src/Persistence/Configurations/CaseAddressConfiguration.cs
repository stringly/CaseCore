using CaseCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Entities.CaseAddress"></see> entity
    /// </summary>
    public class CaseAddressConfiguration : IEntityTypeConfiguration<CaseAddress>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{CaseAddress}"/></param>
        public void Configure(EntityTypeBuilder<CaseAddress> builder)
        {
            builder.HasOne(x => x.Case)
                .WithMany(x => x.Addresses)
                .IsRequired();
            builder.HasOne(x => x.Address);
        }
    }
}
