namespace CurrencyTable.Interfaces
{
    public interface IHttpClientService
    {
        Task<string> RequestGet(string uri);
    }
}
