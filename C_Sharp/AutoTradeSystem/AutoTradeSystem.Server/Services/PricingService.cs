namespace AutoTradeSystem.Server.Services
{
    public class PricingService : IPricingService
    {
        public async Task<decimal> GetCurrentPrice(string Ticker)
        {
            await Task.Delay(100);
            var rand = new Random();
            return new decimal(rand.NextDouble());
        }
        public async Task<decimal> Buy(string Ticker, int Quantity, decimal OriginalPrice)
        {
            var currentPrice = await GetCurrentPrice(Ticker);

            var Difference = OriginalPrice - currentPrice; // for buy this is positive as original > current

            return Difference * Quantity;
        }
        public async Task<decimal> Sell(string Ticker, int Quantity, decimal OriginalPrice)
        {
            var currentPrice = await GetCurrentPrice(Ticker);

            var Difference = currentPrice - OriginalPrice; // for sell this is negative as original < current

            return Difference * Quantity;
        }
    }
}
