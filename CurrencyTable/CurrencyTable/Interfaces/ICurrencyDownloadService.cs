using CurrencyTable.Models.Entities;

namespace CurrencyTable.Interfaces
{
    public interface ICurrencyDownloadService
    {
        public List<Currency> GetCurrentCurrencyTable(bool saveToDb);
        public string DownloadCurrencyTable();
        public List<Currency> ParseData(string responseBody);
    }
}
