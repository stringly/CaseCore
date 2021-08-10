using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CaseCore.Domain.Entities;
using CaseCore.Domain.Types;

namespace CaseCore.Persistence.Configurations
{
    /// <summary>
    /// Implements <see cref="IEntityTypeConfiguration{TEntity}"></see> to configure the <see cref="Domain.Entities.Person"></see> entity
    /// </summary>
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        /// <summary>
        /// Configures the Entity
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{Person}"/></param>
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.Prefix)
                .HasField("_prefix")
                .IsRequired()
                .HasConversion<string>();
            builder.Property(p => p.FirstName)
                .HasField("_firstName")
                .HasMaxLength(100);
            builder.Property(p => p.MiddleName)
                .HasField("_middleName")
                .HasMaxLength(100);
            builder.Property(p => p.LastName)
                .HasField("_lastName")
                .HasMaxLength(100);
            builder.Property(p => p.Suffix)
                .HasField("_suffix")
                .HasMaxLength(10);
            builder.HasOne(typeof(PersonType), "PersonType");
            var navigation1 = builder.Metadata.FindNavigation(nameof(Person.PhoneNumbers));
            navigation1.SetPropertyAccessMode(PropertyAccessMode.Field);
            var navigation2 = builder.Metadata.FindNavigation(nameof(Person.EmailAddresses));
            navigation2.SetPropertyAccessMode(PropertyAccessMode.Field);
            var navigation3 = builder.Metadata.FindNavigation(nameof(Person.Addresses));
            navigation3.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(p => p.Gender)
                .HasField("_gender")
                .IsRequired()
                .HasConversion<string>();
            builder.Property(p => p.Race)
                .HasField("_race")
                .IsRequired()
                .HasConversion<string>();
            builder.Property(p => p.DOB)
                .HasField("_dob");
            builder.Property(p => p.SSN)
                .HasField("_ssn");
            builder.Property(p => p.HeightInInches)
                .HasField("_heightInInches");

        }
    }
}
