using CurrencyTable.Models.Entities;

namespace CurrencyTable.Interfaces
{
    public interface ICurrencyService
    {
        List<Currency> GetAllCurrencies(bool usedb);
        Currency? GetSingleCurrencyByShortName(bool usedb, string shortName);
    }
}
