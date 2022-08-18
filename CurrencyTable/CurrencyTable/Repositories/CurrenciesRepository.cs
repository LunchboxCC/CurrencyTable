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
            return _context.Currencies.GroupBy(c => c.ShortName).Select(c => c.OrderByDescending(c => c.ValidFrom).First()).ToList();
        }

        public Currency? GetCurrencyByShortName(string shortName)
        {
            return _context.Currencies.Where(c => c.ShortName.Equals(shortName.ToUpper())).OrderByDescending(c => c.ValidFrom).FirstOrDefault();
        }

        public int AddIfNotExists(List<Currency> currencies)
        {
            var list = GetAllCurrencies();

            if (list.Count == 0)
                _context.AddRange(currencies);
            else
            {
                foreach (var currency in currencies)
                {
                    if (list.Any(c => c.ShortName.Equals(currency.ShortName) && c.ValidFrom < currency.ValidFrom))
                        _context.Add(currency);
                }
            }

            return _context.SaveChanges();
        }
    }
}
