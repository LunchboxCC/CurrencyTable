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

        public bool AddIfNotExists(List<Currency> currencies)
        {
            var list = _context.Currencies.OrderByDescending(c => c.ValidFrom).GroupBy(c => c.ShortName).Select(g => g.First()).ToList();

            int listCount = list.Count;
            foreach (var currency in currencies)
            {
                if (list.Count() == 0)
                    _context.Add(currency);
                else if (list.Any(c => c.ShortName.Equals(currency.ShortName) && c.ValidFrom != currency.ValidFrom))
                    _context.Add(currency);
            }

            int changes = _context.SaveChanges();

            return changes > 0;
        }
    }
}
