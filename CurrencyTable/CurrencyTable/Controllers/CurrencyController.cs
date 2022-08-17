using AutoMapper;
using CurrencyTable.Interfaces;
using CurrencyTable.Models.DTOs;
using CurrencyTable.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyTable.Controllers
{
    [ApiController]
    [Route("api/currencies")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _service;
        private readonly IParamValidator _validator;
        private readonly IMapper _mapper;

        public CurrencyController(ICurrencyService service, 
                                  IParamValidator validator, 
                                  IMapper mapper)
        {
            _service = service;
            _validator = validator;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieve all currencies
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///     GET /api/currencies?usedb=true
        /// 
        /// </remarks>
        /// <param name="usedb">If currencies should be acquired from DB or by API request.</param>
        /// <returns>Collection of all currencies acquired.</returns>
        /// <response code="200">Returns all found currencies.</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(List<Currency>), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public IActionResult GetAllCurrencies(bool usedb)
        {
            var currencies = _service.GetAllCurrencies(usedb);

            return Ok(_mapper.Map<List<CurrencyDTO>>(currencies));
        }

        /// <summary>
        /// Retrieve detail of a single currency
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///     GET /api/currencies?usedb=true?shortname=DKK
        /// 
        /// </remarks>
        /// <param name="usedb">If currencies should be acquired from DB or by API request.</param>
        /// <param name="shortname">Three-letter name of a currency</param>
        /// <returns>Detail of a single currency.</returns>
        /// <response code="200">Returns a detail of a single currency.</response>
        /// <response code="400">Returns a an error message if shortname parameter doesn't adhere to requirements.</response>
        /// <response code="404">Returns a an error message when no currency was found based on shortname parameter.</response>
        [HttpGet("{shortname}")]
        public IActionResult GetSingleCurrencyDetail(bool usedb, string shortname)
        {
            if (!_validator.ValidateShortName(shortname))
                return BadRequest("Invalid shortname parameter value");

            var currency = _service.GetSingleCurrencyByShortName(usedb, shortname);
            if (currency == null)
                return NotFound("No such currency found");

            return Ok(_mapper.Map<CurrencyDTO>(currency));
        }
    }
}
