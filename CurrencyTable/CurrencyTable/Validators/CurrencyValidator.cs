using CurrencyTable.Interfaces;

namespace CurrencyTable.Validators
{
    public class CurrencyValidator : ICurrencyValidator
    {
        public bool ValidateShortName(string shortName)
        {
            return shortName.Length == 3 && shortName.All(char.IsLetter);
        }
    }
}
