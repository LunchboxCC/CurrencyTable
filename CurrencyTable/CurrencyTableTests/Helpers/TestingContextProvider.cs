using CurrencyTable.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CurrencyTableTests.Helpers
{
    public static class TestingContextProvider
    {
        public static ApplicationContext CreateContext()
        {
            var dbConnection = new SqliteConnection("Datasource=:memory:");
            dbConnection.Open();
            var contextOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlite(dbConnection).Options;
            var context = new ApplicationContext(contextOptions);

            context.Database.EnsureCreated();

            DbSeeder.Seed(context);

            return context;
        }
    }
}
