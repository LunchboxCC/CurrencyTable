using CurrencyTable.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
