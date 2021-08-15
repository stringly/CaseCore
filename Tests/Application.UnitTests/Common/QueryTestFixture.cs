using AutoMapper;
using CaseCore.Application.Common.Mappings;
using CaseCore.Persistence;
using System;
using Xunit;

namespace CaseCore.Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public CaseCoreDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }
        public QueryTestFixture()
        {
            Context = CaseCoreDbContextFactory.Create();
            
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }
        public void Dispose()
        {
            CaseCoreDbContextFactory.Destroy(Context);            
        }
    }
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
