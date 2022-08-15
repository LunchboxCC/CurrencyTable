namespace CurrencyTable.Models.Entities
{
    public class Currency
    {
        public long CurrencyId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Country { get; set; }
        public DateTime ValidFrom { get; set; }
        public double Move { get; set; }
        public int Amount { get; set; }
        public double ValBuy { get; set; }
        public double ValSell { get; set; }
        public double ValMid { get; set; }
        public double CurrBuy { get; set; }
        public double CurrSell { get; set; }
        public double CurrMid { get; set; }
        public int Version { get; set; }
        public double CnbMid { get; set; }
        public double EcbMid { get; set; }
    }
}
