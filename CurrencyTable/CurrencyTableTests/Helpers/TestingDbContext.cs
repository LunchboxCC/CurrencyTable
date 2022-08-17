using CurrencyTable.Database;
using CurrencyTable.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyTableTests.Helpers
{
    public class TestingDbContext : ApplicationContext
    {
        public TestingDbContext()
        {
        }

        public TestingDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Currency>().HasData(DataProvider.GetListOfCurrencies());
        }
    }
}
