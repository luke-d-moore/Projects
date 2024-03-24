namespace AutoTradeSystem.Server.Services
{
    public interface IPricingService
    {
        public Task<decimal> GetCurrentPrice(string Ticker);
        public Task<decimal> Sell(string Ticker, int Quantity, decimal OriginalPrice);
        public Task<decimal> Buy(string Ticker, int Quantity, decimal OriginalPrice);

    }
}