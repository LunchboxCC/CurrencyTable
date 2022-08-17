using CurrencyTable.Models.Entities;
using FluentValidation;

namespace CurrencyTable.Validators
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {
        public CurrencyValidator()
        {
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.ShortName).NotNull().Length(3).Must(sn => sn.All(char.IsLetter));
            RuleFor(c => c.Country).NotNull();
            RuleFor(c => c.ValidFrom).NotNull();
            RuleFor(c => c.Move).NotNull();
            RuleFor(c => c.Amount).NotNull().Must(a => a == 1 || Math.Log10(a) % 1 == 0);
            RuleFor(c => c.ValBuy).NotNull();
            RuleFor(c => c.ValSell).NotNull();
            RuleFor(c => c.ValMid).NotNull();
            RuleFor(c => c.CurrBuy).NotNull();
            RuleFor(c => c.CurrSell).NotNull();
            RuleFor(c => c.CurrMid).NotNull();
            RuleFor(c => c.Version).NotNull().Equals(1);
            RuleFor(c => c.CnbMid).NotNull();
            RuleFor(c => c.EcbMid).NotNull();
        }
    }
}
