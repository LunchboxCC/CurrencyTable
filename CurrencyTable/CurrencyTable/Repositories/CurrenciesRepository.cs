using CurrencyTable.Database;
using CurrencyTable.Interfaces;
using CurrencyTable.Models.Entities;

namespace CurrencyTable.Repositories
{
    public class CurrenciesRepository : ICurrenciesRepository
    {
        private readonly ApplicationContext _context;

        public CurrenciesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Currency> GetAllCurrencies()
        {
            return _context.Currencies.ToList();
        }

        public Currency? GetCurrencyByShortName(string shortName)
        {
            return _context.Currencies.Where(c => c.ShortName.Equals(shortName)).FirstOrDefault();
        }

        public bool AddOrUpdateCurrencyTable(List<Currency> currencies)
        {
            _context.Update(currencies);
            int changes = _context.SaveChanges();

            return changes > 0;
        }
    }
}
