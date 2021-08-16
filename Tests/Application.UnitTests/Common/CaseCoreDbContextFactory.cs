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
            Case newCase = new Case("1234567890", new Address(addressType, "99 Main St.","", "Anytown", "MD", "99999"), new DateTime(2020, 12, 1), new DateTime(2020, 12, 1));
            newCase.UpdateCaseAssignment(context.CaseAssignmentTypes.First(), "testUser", new DateTime(2020, 12, 1), "Test Assignment");
            newCase.UpdateCaseStatus(context.CaseStatusTypes.First(), new DateTime(2020, 12, 1), "Test remarks.");
            Person newPerson = new Person(context.PersonTypes.First(), "Mr", "John", "Q", "Public", "Jr", "M", "W", new DateTime(1980, 1, 1), "123-45-7890");
            newPerson.AddPhoneNumber(new PhoneNumber("1234567890", context.PhoneNumberTypes.First()));
            newCase.AddPerson(newPerson);
            context.Cases.Add(newCase);
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
