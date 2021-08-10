using CaseCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Entities.PersonAddress"></see> entity
    /// </summary>
    public class PersonAddressConfiguration : IEntityTypeConfiguration<PersonAddress>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{PersonAddress}"/></param>
        public void Configure(EntityTypeBuilder<PersonAddress> builder)
        {
            builder.HasOne(x => x.Person)
                .WithMany(x => x.Addresses)
                .IsRequired();
            builder.HasOne(x => x.Address);
                

        }
    }
}
