using AutoMapper;
using CurrencyTable.Interfaces;
using CurrencyTable.Models;
using CurrencyTable.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CurrencyTable.Controllers
{
    [ApiController]
    [Route("api/currencies")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _service;
        private readonly ICurrencyValidator _validator;
        private readonly IMapper _mapper;

        public CurrencyController(ICurrencyService service, 
                                  ICurrencyValidator validator, 
                                  IMapper mapper)
        {
            _service = service;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult GetAllCurrencies(bool usedb)
        {
            var currencies = _service.GetAllCurrencies(usedb);

            return Ok(_mapper.Map<List<CurrencyDTO>>(currencies));
        }

        [HttpGet("{shortName}")]
        public IActionResult GetSingleCurrencyDetail(bool usedb, string shortName)
        {
            if (!_validator.ValidateShortName(shortName))
                return BadRequest("Invalid currency short name");

            var currency = _service.GetSingleCurrencyByShortName(usedb, shortName);
            if (currency == null)
                return NotFound("No such currency found");

            return Ok(_mapper.Map<CurrencyDTO>(currency));
        }
    }
}
