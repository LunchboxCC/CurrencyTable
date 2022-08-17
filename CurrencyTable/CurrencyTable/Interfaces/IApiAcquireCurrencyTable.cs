using CurrencyTable.Models.Entities;

namespace CurrencyTable.Interfaces
{
    public interface IApiAcquireCurrencyTable
    {
        List<Currency> GetCurrentCurrencyTable();
    }
}
