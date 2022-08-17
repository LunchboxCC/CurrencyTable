using CurrencyTable.Interfaces;

namespace CurrencyTable.Validators
{
    public class ParamValidator : IParamValidator
    {
        public bool ValidateShortName(string shortName)
        {
            return shortName.Length == 3 && shortName.All(char.IsLetter);
        }
    }
}
