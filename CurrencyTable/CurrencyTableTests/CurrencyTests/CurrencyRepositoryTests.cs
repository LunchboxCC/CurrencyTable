using CurrencyTable.Interfaces;
using CurrencyTable.Repositories;
using CurrencyTableTests.Helpers;

namespace CurrencyTableTests.CurrencyTests
{
    public class CurrencyRepositoryTests
    {
        private ICurrenciesRepository _repository;

        public CurrencyRepositoryTests()
        {
            _repository = new CurrenciesRepository(TestingContextProvider.CreateContext());
        }

        [Fact]
        public void AddIfNotExistsChecksForExistingData()
        {
            var inputCurrencies = DataProvider.GetListOfCurrencies().Take(4).ToList();
            inputCurrencies[0].ValidFrom = inputCurrencies[0].ValidFrom.AddDays(1);
            inputCurrencies[2].ValidFrom = inputCurrencies[2].ValidFrom.AddDays(1);

            var expectedResult = 2;

            var actualResult = _repository.AddIfNotExists(inputCurrencies);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
