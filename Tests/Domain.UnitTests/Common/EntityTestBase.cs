using Xunit;

namespace CaseCore.Domain.UnitTests.Common
{
    public abstract class EntityTestBase
    {
#pragma warning disable IDE1006 // Naming Styles
        protected readonly TestEntityFactory _factory;
#pragma warning restore IDE1006 // Naming Styles

        public EntityTestBase()
        {
            _factory = new TestEntityFactory();
        }

    }
}
