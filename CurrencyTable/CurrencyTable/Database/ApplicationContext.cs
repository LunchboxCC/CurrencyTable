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
            base.OnModelCreating(modelBuilder);
        }
    }
}
