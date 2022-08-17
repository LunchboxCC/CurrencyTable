namespace CurrencyTable.Interfaces
{
    public interface IParamValidator
    {
        bool ValidateUsedb(bool usedb);
        bool ValidateShortName(string shortName);
    }
}
