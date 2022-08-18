using CurrencyTable.ApiServices;
using CurrencyTable.Interfaces;
using CurrencyTable.Validators;
using CurrencyTableTests.Helpers;
using Moq;
using Newtonsoft.Json;

namespace CurrencyTableTests.CurrencyTests
{
    public class ApiDownloadTests
    {
        private IApiDownloadCurrencyTable? _api;

        [Fact]
        public void ApiDownloadParsesContentAndReturnsListOfCurrencies()
        {
            var expectedCurrencies = DataProvider.GetListOfCurrencies();
            int expectedCount = expectedCurrencies.Count;

            var client = new Mock<IHttpClientService>();
            client.Setup(c => c.RequestGet(It.IsAny<string>()).Result).Returns(DataProvider.GetApiResponseString());

            var repository = new Mock<ICurrenciesRepository>();
            repository.Setup(r => r.AddIfNotExists(expectedCurrencies)).Returns(0);

            _api = new ApiDownloadCurrencyTableErste(client.Object, repository.Object, new CurrencyValidator());

            var actualCurrencies = _api.GetCurrentCurrencyTable();

            Assert.Equal(expectedCount, actualCurrencies.Count);
            Assert.Equal(JsonConvert.SerializeObject(expectedCurrencies), JsonConvert.SerializeObject(actualCurrencies));
        }
    }
}
