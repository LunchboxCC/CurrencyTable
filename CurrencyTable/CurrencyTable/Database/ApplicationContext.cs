using CurrencyTable.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyTable.Database
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Currency> Currencies { get; set; }

        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var currency = modelBuilder.Entity<Currency>();
            currency.Property(c => c.Name).HasColumnName("varchar(20)");
            currency.Property(c => c.ShortName).HasColumnType("varchar(3)");
            currency.Property(c => c.Country).HasColumnType("varchar(80)");
            currency.Property(c => c.Amount).HasColumnType("smallint");
            currency.Property(c => c.Version).HasColumnType("smallint");
        }
    }
}
