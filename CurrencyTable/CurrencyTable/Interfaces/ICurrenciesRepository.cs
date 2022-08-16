using CurrencyTable.Models.Entities;

namespace CurrencyTable.Interfaces
{
    public interface ICurrenciesRepository
    {
        List<Currency> GetAllCurrencies();
        Currency? GetCurrencyByShortName(string shortName);
        bool AddIfNotExists(List<Currency> currencies);
    }
}
