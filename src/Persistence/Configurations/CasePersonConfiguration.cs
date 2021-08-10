using CaseCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Entities.CasePerson"></see> entity
    /// </summary>
    public class CasePersonConfiguration : IEntityTypeConfiguration<CasePerson>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{CasePerson}"/></param>
        public void Configure(EntityTypeBuilder<CasePerson> builder)
        {
            builder.HasOne(x => x.Case)
                .WithMany(x => x.Persons)
                .IsRequired();
            builder.HasOne(x => x.Person);
        }
    }
}
