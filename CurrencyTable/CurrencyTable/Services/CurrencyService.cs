using CurrencyTable.Interfaces;
using CurrencyTable.Models.Entities;

namespace CurrencyTable.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrenciesRepository _currenciesRepository;

        public List<Currency> GetAllCurrencies(bool usedb)
        {
            throw new NotImplementedException();
        }

        public Currency GetCurrencyDetail(bool usedb, string shortName)
        {
            throw new NotImplementedException();
        }

        public List<Currency> FetchFromApi()
        {
            throw new NotImplementedException();
        }

        public List<Currency> FetchFromDatabase()
        {
            return _currenciesRepository.GetAllCurrencies();             
        }

        public Currency? FetchSingleCurrencyFromDatabase(string shortName)
        {
            return _currenciesRepository.GetCurrencyByShortName(shortName);
        }
    }
}
