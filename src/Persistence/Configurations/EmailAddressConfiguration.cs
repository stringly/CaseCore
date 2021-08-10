using CaseCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Entities.EmailAddress"></see> entity
    /// </summary>
    public class EmailAddressConfiguration : IEntityTypeConfiguration<EmailAddress>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{EmailAddress}"/></param>
        public void Configure(EntityTypeBuilder<EmailAddress> builder)
        {
            builder.Property(e => e.Address)
                .HasField("_emailAddress")
                .IsRequired()
                .HasMaxLength(200);            

        }
    }
}
