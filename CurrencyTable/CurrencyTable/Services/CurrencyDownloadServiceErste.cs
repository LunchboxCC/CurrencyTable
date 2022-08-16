using CurrencyTable.Interfaces;
using CurrencyTable.Models.Entities;
using System.Text.Json;

namespace CurrencyTable.Services
{
    public class CurrencyDownloadServiceErste : ICurrencyDownloadService
    {
        private readonly IHttpClientService _httpClientService;

        public CurrencyDownloadServiceErste(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public List<Currency>? GetCurrentCurrencyTable(bool saveToDb)
        {
            string responseContent = DownloadCurrencyTable();
            var list = ParseData(responseContent);

            return list;
        }

        public string DownloadCurrencyTable()
        {
            string uri = "https://webapi.developers.erstegroup.com/api/csas/public/sandbox/v2/rates/exchangerates?web-api-key=c52a0682-4806-4903-828f-6cc66508329e"; 
            return _httpClientService.RequestGet(uri).Result;        
        }

        public List<Currency>? ParseData(string responseContent)
        {
            return JsonSerializer.Deserialize<List<Currency>>(responseContent, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
    }
}
