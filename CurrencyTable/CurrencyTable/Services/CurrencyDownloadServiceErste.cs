using CurrencyTable.Interfaces;
using CurrencyTable.Models.Entities;
using FluentValidation;
using System.Text.Json;

namespace CurrencyTable.Services
{
    public class CurrencyDownloadServiceErste : ICurrencyDownloadService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ICurrenciesRepository _currenciesRepository;
        private readonly IValidator<Currency> _validator;

        public CurrencyDownloadServiceErste(IHttpClientService httpClientService, 
                                            ICurrenciesRepository currenciesRepository, 
                                            IValidator<Currency> validator)
        {
            _httpClientService = httpClientService;
            _currenciesRepository = currenciesRepository;
            _validator = validator;
        }

        public List<Currency> GetCurrentCurrencyTable()
        {
            string responseContent = DownloadCurrencyTable();
            var currencies = ParseData(responseContent);
            ValidateData(currencies);

            SaveToDb(currencies);
                
            return currencies ?? new List<Currency>();
        }

        public string DownloadCurrencyTable()
        {
            string uri = "https://webapi.developers.erstegroup.com/api/csas/public/sandbox/v2/rates/exchangerates?web-api-key=c52a0682-4806-4903-828f-6cc66508329e"; 
            return _httpClientService.RequestGet(uri).Result;        
        }

        public List<Currency>? ParseData(string responseContent)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Deserialize<List<Currency>>(responseContent, options);
        }

        private void ValidateData(List<Currency>? currencies)
        {
            foreach (var currency in currencies)
            {
                _validator.ValidateAndThrow(currency);
            }
        }

        public void SaveToDb(List<Currency> currencies)
        {
            _currenciesRepository.AddIfNotExists(currencies);
        }
    }
}
