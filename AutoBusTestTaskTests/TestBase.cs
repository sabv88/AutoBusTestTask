using AutoBusTestTask.Data;
using AutoBusTestTaskTests.Url;

namespace AutoBusTestTaskTests
{
    public abstract class TestBase : IDisposable
    {
        protected readonly AutoBusTestTaskDbContext Context;

        public TestBase()
        {
            Context = UrlContextFactory.Create();
        }

        public void Dispose()
        {
            UrlContextFactory.Destroy(Context);
        }
    }
}
