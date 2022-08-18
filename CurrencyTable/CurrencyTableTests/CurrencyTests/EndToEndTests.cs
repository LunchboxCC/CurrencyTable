using CurrencyTableTests.Helpers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using CurrencyTable.Models.DTOs;

namespace CurrencyTableTests.CurrencyTests
{
    public class EndToEndTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public EndToEndTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllCurrenciesReturns200AndValidListOfCurrencies()
        {
            var expectedCount = 20;
            var expectedStatusCode = 200;
            var expectedCurrencies = DataProvider.GetListOfCurrenciesDTO();

            var usedb = true;

            var response = await _factory.CreateClient().GetAsync($"/api/currencies?usedb={usedb}");
            var content = await response.Content.ReadAsStringAsync();
            var actualCurrencies = JsonConvert.DeserializeObject<List<CurrencyDTO>>(content);

            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
            Assert.Equal(expectedCount, actualCurrencies.Count);

            actualCurrencies = actualCurrencies.OrderBy(c => c.Name).ToList();
            expectedCurrencies = expectedCurrencies.OrderBy(c => c.Name).ToList();
            Assert.Equal(JsonConvert.SerializeObject(expectedCurrencies), JsonConvert.SerializeObject(actualCurrencies));
        }

        [Fact]
        public async Task GetAllCurrenciesReturns200AndValidListOfCurrenciesFromApi()
        {
            var expectedCount = 20;
            var expectedStatusCode = 200;

            var validator = _factory.Services.CreateScope().ServiceProvider.GetRequiredService<IValidator<CurrencyDTO>>();
            var usedb = false;

            var response = await _factory.CreateClient().GetAsync($"/api/currencies?usedb={usedb}");
            var content = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<CurrencyDTO>>(content);

            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
            Assert.Equal(expectedCount, list.Count);

            foreach (var currency in list)
            {
                Assert.True(validator.Validate(currency).IsValid);
            }
        }

        [Fact]
        public async Task GetSingleCurrencyReturns200AndCurrencyOnValidParam()
        {
            var expectedCurrency = new CurrencyDTO()
            {
                Name = "Krone",
                ShortName = "DKK",
                Country = "Denmark",
                ValidFrom = DateTime.Parse("2022-04-26T00:00:00"),
                Move = 0.37,
                Amount = 1,
                ValBuy = 3.17,
                ValSell = 3.4,
                ValMid = 3.284,
                CurrBuy = 3.202,
                CurrSell = 3.366,
                CurrMid = 3.284,
                Version = 1,
                CnbMid = 3.283,
                EcbMid = 7.439
            };
            var expectedStatusCode = 200;

            var usedb = true;
            var shortname = "DKK";

            var response = await _factory.CreateClient().GetAsync($"/api/currencies/{shortname}?usedb={usedb}");
            var content = await response.Content.ReadAsStringAsync();
            var currency = JsonConvert.DeserializeObject<CurrencyDTO>(content);

            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(expectedCurrency), JsonConvert.SerializeObject(currency));
        }

        [Fact]
        public async Task GetSingleCurrencyReturns400OnInvalidShortnameParam()
        {
            var expectedResponse = "Invalid shortname parameter value";
            var expectedStatusCode = 400;

            var usedb = true;
            var shortname = "invalid";

            var response = await _factory.CreateClient().GetAsync($"/api/currencies/{shortname}?usedb={usedb}");
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
            Assert.Equal(expectedResponse, content);
        }

        [Fact]
        public async Task GetSingleCurrencyReturns404OnCurrencyNotFound()
        {
            var expectedResponse = "No such currency found";
            var expectedStatusCode = 404;

            var usedb = true;
            var shortname = "czk";

            var response = await _factory.CreateClient().GetAsync($"/api/currencies/{shortname}?usedb={usedb}");
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
            Assert.Equal(expectedResponse, content);
        }
    }
}
