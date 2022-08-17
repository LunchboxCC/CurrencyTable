using CurrencyTable.Models.Entities;

namespace CurrencyTable.Interfaces
{
    public interface ICurrenciesRepository
    {
        List<Currency> GetAllCurrencies();
        Currency? GetCurrencyByShortName(string shortName);
        int AddIfNotExists(List<Currency> currencies);
    }
}
