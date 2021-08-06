using CaseCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Entities.PersonEmailAddress"></see> entity
    /// </summary>
    public class PersonEmailAddressesConfiguration : IEntityTypeConfiguration<PersonEmailAddress>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{PersonEmailAddress}"/></param>
        public void Configure(EntityTypeBuilder<PersonEmailAddress> builder)
        {
            builder.HasOne(x => x.Person)
                .WithMany(x => x.EmailAddresses)
                .IsRequired();
            builder.HasOne(x => x.EmailAddress);


        }
    }
}
