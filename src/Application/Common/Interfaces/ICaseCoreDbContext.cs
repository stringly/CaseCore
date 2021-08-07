﻿using CaseCore.Domain.Entities;
using CaseCore.Domain.Types;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.Common.Interfaces
{
    /// <summary>
    /// Interface that set defines the contract for the DbContext used in the application layer
    /// </summary>
    public interface ICaseCoreDbContext
    {
        /// <summary>
        /// A <seealso cref="DbSet{Case}"/> containing Case entities.
        /// </summary>
        DbSet<Case> Cases { get; set; }
        /// <summary>
        /// A <seealso cref="DbSet{Address}"/> containing Address entities.
        /// </summary>
        DbSet<Address> Addresses { get; set; }
        /// <summary>
        /// A <seealso cref="DbSet{Person}"/> containing Person entities.
        /// </summary>
        DbSet<Person> Persons { get;set;}
        /// <summary>
        /// A <seealso cref="DbSet{AddressType}"/> containing AddressType entities.
        /// </summary>
        DbSet<AddressType> AddressTypes { get;set;}
        /// <summary>
        /// A <seealso cref="DbSet{PersonType}"/> containing PersonType entities.
        /// </summary>
        DbSet<PersonType> PersonTypes { get;set;}
        /// <summary>
        /// A <seealso cref="DbSet{PhoneNumberType}"/> containing PhoneNumberType entities.
        /// </summary>
        DbSet<PhoneNumberType> PhoneNumberTypes { get;set;}
        /// <summary>
        /// Saves the changes to the Context
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"></see></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}