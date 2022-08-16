using CurrencyTable.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyTable.Controllers
{
    [ApiController]
    [Route("api/currencies")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _service;
        private readonly ICurrencyValidator _validator;

        public CurrencyController(ICurrencyService service, ICurrencyValidator validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet("")]
        public IActionResult GetAllCurrencies(bool usedb)
        {
            var currencies = _service.GetAllCurrencies(usedb);

            return Ok(currencies);
        }

        [HttpGet("{shortName}")]
        public IActionResult GetSingleCurrencyDetail(bool usedb, string shortName)
        {
            if (!_validator.ValidateShortName(shortName))
                return BadRequest("Invalid currency short name");

            var currency = _service.GetCurrencyDetail(usedb, shortName);

            return currency != null ? Ok(currency) : BadRequest("No currency of this name found");
        }
    }
}
