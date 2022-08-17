using CurrencyTable.Models.Entities;
using CurrencyTableTests.Helpers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
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
        public async Task LoginWithCorrectLoginCredentialsReturns200Response()
        {
            //Arrange
            var expectedCount = 20;
            var expectedStatusCode = 200;

            var usedb = true;

            //Act
            var response = await _factory.CreateClient().GetAsync($"/api/currencies?usedb={usedb}");
            var content = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<CurrencyDTO>>(content);

            //Assert
            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
            Assert.Equal(expectedCount, list.Count);

            var validator = _factory.Services.CreateScope().ServiceProvider.GetRequiredService<IValidator<CurrencyDTO>>();
            Assert.True(validator.Validate(list.FirstOrDefault()).IsValid);
        }
    }
}
