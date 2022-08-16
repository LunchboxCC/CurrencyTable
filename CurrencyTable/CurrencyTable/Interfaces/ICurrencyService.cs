using CurrencyTable.Models.Entities;

namespace CurrencyTable.Interfaces
{
    public interface ICurrencyService
    {
        List<Currency> GetAllCurrencies(bool usedb);
        Currency GetCurrencyDetail(bool usedb, string shortName);
        List<Currency> FetchFromDatabase();
        Currency? FetchSingleCurrencyFromDatabase(string shortName);
        List<Currency> FetchFromApi(bool saveToDb);
    }
}
