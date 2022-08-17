﻿using CurrencyTable.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyTableTests.Helpers
{
    public static class DataProvider
    {
        public static string GetApiResponseString()
        {
            return @"[{""shortName"":""AUD"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Dollar"",
                       ""country"":""Australia"",""move"":-0.5,""amount"":1,""valBuy"":15.74,""valSell"":16.88,""valMid"":16.306,
                       ""currBuy"":15.898,""currSell"":16.714,""currMid"":16.306,""version"":1,
                       ""cnbMid"":16.31,""ecbMid"":1.497},
                      {""shortName"":""ZAR"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Rand"",
                       ""country"":""South Africa"",""move"":0,""amount"":1,""valBuy"":0,""valSell"":0,""valMid"":0,
                       ""currBuy"":1.409,""currSell"":1.482,""currMid"":1.445,""version"":1,
                       ""cnbMid"":1.449,""ecbMid"":16.855},
                      {""shortName"":""CAD"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Dollar"",
                       ""country"":""Canada"",""move"":0.52,""amount"":1,""valBuy"":17.24,""valSell"":18.49,""valMid"":17.865,
                       ""currBuy"":17.418,""currSell"":18.312,""currMid"":17.865,""version"":1,""cnbMid"":17.814,""ecbMid"":1.371},{""shortName"":""CHF"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Franc"",""country"":""Switzerland"",""move"":1.13,""amount"":1,""valBuy"":22.99,""valSell"":24.65,""valMid"":23.82,""currBuy"":23.224,""currSell"":24.415,""currMid"":23.82,""version"":1,""cnbMid"":23.784,""ecbMid"":1.027},{""shortName"":""DKK"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Krone"",""country"":""Denmark"",""move"":0.37,""amount"":1,""valBuy"":3.17,""valSell"":3.4,""valMid"":3.284,""currBuy"":3.202,""currSell"":3.366,""currMid"":3.284,""version"":1,""cnbMid"":3.283,""ecbMid"":7.439},{""shortName"":""EUR"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Euro"",""country"":""EU"",""move"":0.37,""amount"":1,""valBuy"":23.57,""valSell"":25.29,""valMid"":24.43,""currBuy"":23.819,""currSell"":25.041,""currMid"":24.43,""version"":1,""cnbMid"":24.42,""ecbMid"":0},{""shortName"":""GBP"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Pound"",""country"":""Great Britain"",""move"":0.03,""amount"":1,""valBuy"":28.01,""valSell"":30.04,""valMid"":29.028,""currBuy"":28.303,""currSell"":29.754,""currMid"":29.028,""version"":1,""cnbMid"":28.956,""ecbMid"":0.843},{""shortName"":""HKD"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Dollar"",""country"":""Hong Kong"",""move"":1.04,""amount"":1,""valBuy"":0,""valSell"":0,""valMid"":0,""currBuy"":2.832,""currSell"":2.978,""currMid"":2.905,""version"":1,""cnbMid"":2.896,""ecbMid"":8.433},{""shortName"":""HRK"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Kuna"",""country"":""Croatia"",""move"":0.37,""amount"":1,""valBuy"":3.12,""valSell"":3.34,""valMid"":3.23,""currBuy"":3.149,""currSell"":3.311,""currMid"":3.23,""version"":1,""cnbMid"":3.23,""ecbMid"":7.562},{""shortName"":""HUF"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Forint"",""country"":""Hungary"",""move"":-0.37,""amount"":100,""valBuy"":6.3,""valSell"":6.76,""valMid"":6.531,""currBuy"":6.368,""currSell"":6.694,""currMid"":6.531,""version"":1,""cnbMid"":6.528,""ecbMid"":37408},{""shortName"":""JPY"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Yen"",""country"":""Japan"",""move"":1.36,""amount"":100,""valBuy"":17.2,""valSell"":18.45,""valMid"":17.823,""currBuy"":17.377,""currSell"":18.268,""currMid"":17.823,""version"":1,""cnbMid"":17.729,""ecbMid"":13773},{""shortName"":""NOK"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Krone"",""country"":""Norway"",""move"":-0.99,""amount"":1,""valBuy"":2.41,""valSell"":2.59,""valMid"":2.499,""currBuy"":2.437,""currSell"":2.562,""currMid"":2.499,""version"":1,""cnbMid"":2.517,""ecbMid"":9.702},{""shortName"":""NZD"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Dollar"",""country"":""New Zealand"",""move"":0.53,""amount"":1,""valBuy"":0,""valSell"":0,""valMid"":0,""currBuy"":14.674,""currSell"":15.426,""currMid"":15.05,""version"":1,""cnbMid"":15.037,""ecbMid"":1.624},{""shortName"":""PLN"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Złoty"",""country"":""Poland"",""move"":0.31,""amount"":1,""valBuy"":5.07,""valSell"":5.44,""valMid"":5.255,""currBuy"":5.123,""currSell"":5.386,""currMid"":5.255,""version"":1,""cnbMid"":5.264,""ecbMid"":4.64},{""shortName"":""RON"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Leu"",""country"":""Romania"",""move"":0.33,""amount"":1,""valBuy"":0,""valSell"":0,""valMid"":0,""currBuy"":4.816,""currSell"":5.063,""currMid"":4.939,""version"":1,""cnbMid"":4.938,""ecbMid"":4.946},{""shortName"":""SEK"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Krona"",""country"":""Sweden"",""move"":-0.59,""amount"":1,""valBuy"":2.27,""valSell"":2.44,""valMid"":2.354,""currBuy"":2.295,""currSell"":2.413,""currMid"":2.354,""version"":1,""cnbMid"":2.36,""ecbMid"":10.348},{""shortName"":""TND"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Dinar"",""country"":""Tunisia"",""move"":-0.25,""amount"":1,""valBuy"":0,""valSell"":0,""valMid"":0,""currBuy"":7.284,""currSell"":7.657,""currMid"":7.471,""version"":1,""cnbMid"":0,""ecbMid"":0},{""shortName"":""TRY"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Lira"",""country"":""Turkey"",""move"":0.92,""amount"":1,""valBuy"":0,""valSell"":0,""valMid"":0,""currBuy"":1.504,""currSell"":1.581,""currMid"":1.543,""version"":1,""cnbMid"":1.539,""ecbMid"":15.864},{""shortName"":""USD"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Dollar"",""country"":""USA"",""move"":1.07,""amount"":1,""valBuy"":22,""valSell"":23.6,""valMid"":22.798,""currBuy"":22.228,""currSell"":23.368,""currMid"":22.798,""version"":1,""cnbMid"":22.725,""ecbMid"":1.075},{""shortName"":""BGN"",""validFrom"":""2022-04-26T00:00:00"",""name"":""Lev"",""country"":""Bulgaria"",""move"":0.35,""amount"":1,""valBuy"":0,""valSell"":0,""valMid"":0,""currBuy"":12.177,""currSell"":12.802,""currMid"":12.489,""version"":1,""cnbMid"":12.486,""ecbMid"":1.956}]";
        }

        public static List<Currency> GetListOfCurrencies()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Deserialize<List<Currency>>(GetApiResponseString(), options);
        }
    }
}