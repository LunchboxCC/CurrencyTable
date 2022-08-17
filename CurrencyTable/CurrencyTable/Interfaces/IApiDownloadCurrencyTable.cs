using CurrencyTable.Models.Entities;

namespace CurrencyTable.Interfaces
{
    public interface IApiDownloadCurrencyTable
    {
        List<Currency> GetCurrentCurrencyTable();
    }
}
