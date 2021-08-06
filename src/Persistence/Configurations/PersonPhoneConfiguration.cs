using CaseCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Entities.PersonPhoneNumber"></see> entity
    /// </summary>
    public class PersonPhoneConfiguration : IEntityTypeConfiguration<PersonPhoneNumber>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{PersonPhoneNumber}"/></param>
        public void Configure(EntityTypeBuilder<PersonPhoneNumber> builder)
        {
            builder.HasOne(x => x.Person)
                .WithMany(x => x.PhoneNumbers)
                .IsRequired();
            builder.HasOne(x => x.PhoneNumber);


        }
    }
}
