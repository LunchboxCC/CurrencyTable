using CurrencyTable.Interfaces;
using CurrencyTable.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTableTests.CurrencyTests
{
    public class ParamValidationUnitTests
    {
        private readonly IParamValidator _validator;

        public ParamValidationUnitTests()
        {
            _validator = new ParamValidator();
        }

        [Theory]
        [InlineData("DKK", true)]
        [InlineData("1sd", false)]
        [InlineData("Krone", false)]
        public void ShortNameIsValidated(string shortname, bool expected)
        {
            Assert.Equal(expected, _validator.ValidateShortName(shortname));
        }
    }
}
