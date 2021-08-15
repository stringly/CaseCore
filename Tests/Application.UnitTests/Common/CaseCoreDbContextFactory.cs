using Microsoft.EntityFrameworkCore;
using CaseCore.Domain.Entities;
using CaseCore.Persistence;
using System;
using System.Linq;
using CaseCore.Domain.Types;

namespace CaseCore.Application.UnitTests.Common
{
    public class CaseCoreDbContextFactory
    {
        public static CaseCoreDbContext Create()
        {
            var options = new DbContextOptionsBuilder<CaseCoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new CaseCoreDbContext(options, new CurrentUserServiceTesting(), new DateTimeTestProvider());
            context.Database.EnsureCreated();
            // Add entities here
            AddressType addressType = context.AddressTypes.First();
            context.Addresses.Add(new Address(addressType, "123 Anywhere St.", "", "Yourtown", "MD", "12345"));
            context.SaveChanges();
            return context;
        }
        public static void Destroy(CaseCoreDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
