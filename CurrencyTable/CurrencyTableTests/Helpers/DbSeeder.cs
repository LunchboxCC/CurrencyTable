using CurrencyTable.Database;

namespace CurrencyTableTests.Helpers
{
    public class DbSeeder
    {
        public static void Seed(ApplicationContext context)
        {
            context.Currencies.AddRange(DataProvider.GetListOfCurrencies());
            context.SaveChanges();
        }
    }
}
