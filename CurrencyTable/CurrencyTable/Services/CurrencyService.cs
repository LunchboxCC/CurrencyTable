using CurrencyTable.Interfaces;
using CurrencyTable.Models.Entities;

namespace CurrencyTable.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrenciesRepository _currenciesRepository;
        private readonly IApiDownloadCurrencyTable _currencyDownloadService;

        public CurrencyService(ICurrenciesRepository currenciesRepository, IApiDownloadCurrencyTable currencyDownloadService)
        {
            _currenciesRepository = currenciesRepository;
            _currencyDownloadService = currencyDownloadService;
        }

        public List<Currency> GetAllCurrencies(bool usedb)
        {
            if (usedb)
                return _currenciesRepository.GetAllCurrencies();
            else
                return _currencyDownloadService.GetCurrentCurrencyTable();
        }

        public Currency? GetSingleCurrencyByShortName(bool usedb, string shortName)
        {
            if (usedb)
                return _currenciesRepository.GetCurrencyByShortName(shortName);
            else
                return _currencyDownloadService.GetCurrentCurrencyTable().FirstOrDefault(c => c.ShortName.Equals(shortName));
        }
    }
}
