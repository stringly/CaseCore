using System;
using System.Collections.Generic;
using System.Text;
using CaseCore.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using CaseCore.Common;
using CaseCore.Domain.Common;
using CaseCore.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CaseCore.Domain.Types;
using System.Diagnostics;
using CaseCore.Persistence.Configurations;

namespace CaseCore.Persistence
{
    public class CaseCoreDbContext : DbContext, ICaseCoreDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        /// <summary>
        /// Creates a new instance of the <see cref="CaseCoreDbContext"/> class.
        /// </summary>
        /// <param name="options">An implementation of <see cref="DbContextOptions{CaseCoreDbContext}"/></param>
        public CaseCoreDbContext(DbContextOptions<CaseCoreDbContext> options) : base(options) { }
        /// <summary>
        /// Creates a new instance of the <see cref="CaseCoreDbContext"></see>
        /// </summary>
        /// <param name="options">An implementation of <see cref="DbContextOptions{CaseCoreDbContext}"/></param>
        /// <param name="currentUserService">An implementation of <see cref="ICurrentUserService"/></param>
        /// <param name="dateTime">An implementation of <see cref="IDateTime"/></param>
        public CaseCoreDbContext(
            DbContextOptions<CaseCoreDbContext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }
        /// <inheritdoc/>
        public DbSet<Case> Cases { get; set; }
        /// <inheritdoc/>
        public DbSet<Address> Addresses { get; set; }
        /// <inheritdoc/>
        public DbSet<Person> Persons { get; set; }
        /// <inheritdoc/>
        public DbSet<AddressType> AddressTypes { get; set; }
        /// <inheritdoc/>
        public DbSet<PersonType> PersonTypes { get; set; }
        /// <inheritdoc/>
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        /// <summary>
        /// Saves changes to the context.
        /// </summary>
        /// <remarks>
        /// This override handles writing metadata to added/updated <see cref="AuditableEntity"/> entities.
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {                
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _currentUserService.UserId;
                        break;
                }
            }
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.Modified = _dateTime.Now;
                        break;                    
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Override that saves changes
        /// </summary>
        /// <remarks>
        /// This override handles writing metadata to added/updated <see cref="AuditableEntity"/> entities.
        /// </remarks>
        /// <returns></returns>
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _currentUserService.UserId;
                        break;
                }
            }
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.Modified = _dateTime.Now;
                        break;
                }
            }
            return base.SaveChanges();
        }
        /// <summary>
        /// Executes instructions when the model is created.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CaseCoreDbContext).Assembly);

            modelBuilder.Entity<AddressType>().HasData( 
                new { Id = 1, Name = "Location of Incident", Abbreviation = "LOI" },
                new { Id = 2, Name = "Home Address", Abbreviation = "HOME" },
                new { Id = 3, Name = "Work Address", Abbreviation = "WORK" },
                new { Id = 4, Name = "Mailing Address", Abbreviation = "MAIL" },
                new { Id = 5, Name = "Location of Apprehension", Abbreviation = "LOA" }
                );
            modelBuilder.Entity<PhoneNumberType>().HasData(
                new { Id = 1, Name = "Home", Abbreviation = "H" },
                new { Id = 2, Name = "Work", Abbreviation = "W" },
                new { Id = 3, Name = "Mobile", Abbreviation = "M"},
                new { Id = 4, Name = "Fax", Abbreviation = "F"}
                );
            modelBuilder.Entity<PersonType>().HasData(
                new { Id = 1, Name = "Victim", Abbreviation = "V" },
                new { Id = 2, Name = "Witness", Abbreviation = "W" },
                new { Id = 3, Name = "Suspect", Abbreviation = "S" },
                new { Id = 4, Name = "Point of Contact", Abbreviation = "POC" },
                new { Id = 5, Name = "Next of Kin", Abbreviation = "NOK" },
                new { Id = 6, Name = "Arrestee", Abbreviation = "A" },
                new { Id = 7, Name = "Other", Abbreviation = "O" }                
                );
            modelBuilder.Entity<OffenseType>().HasData(
                new { Id = 1, Name = "Homicide", Abbreviation = "HOMI"},
                new { Id = 2, Name = "Rape", Abbreviation = "RAPE"},
                new { Id = 3, Name = "Robbery", Abbreviation = "ROBB"}
                );
            modelBuilder.Entity<CaseAssignmentType>().HasData(
                new { Id = 1, Name = "Initial" },
                new { Id = 2, Name = "Reassigned" }
                );
            modelBuilder.Entity<CaseStatusType>().HasData(
                new { Id = 1, Name = "Open" },
                new { Id = 2, Name = "InActive"},
                new { Id = 3, Name = "Closed (Arrest)" },
                new { Id = 4, Name = "Closed (Admin)" },
                new { Id = 5, Name = "Closed (Exception)" }
                );

        }
    }
}
