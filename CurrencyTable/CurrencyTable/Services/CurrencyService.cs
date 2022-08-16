using CurrencyTable.Interfaces;
using CurrencyTable.Models.Entities;

namespace CurrencyTable.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrenciesRepository _currenciesRepository;
        private readonly ICurrencyDownloadService _currencyDownloadService;

        public CurrencyService(ICurrenciesRepository currenciesRepository, ICurrencyDownloadService currencyDownloadService)
        {
            _currenciesRepository = currenciesRepository;
            _currencyDownloadService = currencyDownloadService;
        }

        public List<Currency> GetAllCurrencies(bool usedb)
        {
            return FetchFromSource(usedb);
        }

        public Currency GetCurrencyDetail(bool usedb, string shortName)
        {
            throw new NotImplementedException();
        }

        public List<Currency> FetchFromApi(bool saveToDb)
        {
            var currencies = _currencyDownloadService.GetCurrentCurrencyTable();

            if (saveToDb)
                _currenciesRepository.AddIfNotExists(currencies);

            return currencies;
        }

        public List<Currency> FetchFromDatabase()
        {
            return _currenciesRepository.GetAllCurrencies();             
        }

        public Currency? FetchSingleCurrencyFromDatabase(string shortName)
        {
            return _currenciesRepository.GetCurrencyByShortName(shortName);
        }

        public List<Currency> FetchFromSource(bool usedb)
        {
            if (usedb)
                return FetchFromDatabase();
            else
                return FetchFromApi(true);
        }
    }
}
