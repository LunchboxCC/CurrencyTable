using CurrencyTable.Models.Entities;

namespace CurrencyTable.Interfaces
{
    public interface ICurrencyDownloadService
    {
        List<Currency>? GetCurrentCurrencyTable(bool saveToDb);
        string DownloadCurrencyTable();
        List<Currency>? ParseData(string responseContent);
    }
}
