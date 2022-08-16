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
            List<Currency> currencies;

            if (usedb)
                currencies = FetchFromDatabase();
            else
                currencies = FetchFromApi();

            return currencies;
        }

        public Currency GetCurrencyDetail(bool usedb, string shortName)
        {
            throw new NotImplementedException();
        }

        public List<Currency> FetchFromApi()
        {
            return _currencyDownloadService.GetCurrentCurrencyTable(saveToDb: true);
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
