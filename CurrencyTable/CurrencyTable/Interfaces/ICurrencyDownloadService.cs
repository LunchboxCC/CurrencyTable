using CurrencyTable.Models.Entities;

namespace CurrencyTable.Interfaces
{
    public interface ICurrencyDownloadService
    {
        List<Currency>? GetCurrentCurrencyTable();
        string DownloadCurrencyTable();
        List<Currency>? ParseData(string responseContent);
    }
}
