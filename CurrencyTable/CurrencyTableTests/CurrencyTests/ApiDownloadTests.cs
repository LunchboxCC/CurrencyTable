using CurrencyTable.Interfaces;
using CurrencyTable.Models.Entities;
using CurrencyTable.Services;
using CurrencyTable.Validators;
using CurrencyTableTests.Helpers;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyTableTests.CurrencyTests
{
    public class ApiDownloadTests
    {
        private IApiDownloadCurrencyTable _api;

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
            Assert.Equal(JsonSerializer.Serialize(expectedCurrencies), JsonSerializer.Serialize(actualCurrencies));
        }
    }
}
