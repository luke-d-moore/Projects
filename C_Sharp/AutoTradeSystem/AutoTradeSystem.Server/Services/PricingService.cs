﻿namespace AutoTradeSystem.Server.Services
{
    public class PricingService : IPricingService
    {
        private readonly List<string> _tickers = new List<string>() { "ABCDE", "GOOG", "TFL", "AMZN", "TEST"};
        //These would be accessed from the database, but here I have hardcoded for testing
        public async Task<decimal> GetCurrentPrice(string Ticker)
        {
            await Task.Delay(100);
            if (_tickers.Contains(Ticker))
            {
                var rand = new Random();
                return new decimal(rand.NextDouble());
            }
            else
            {
                throw new ArgumentException("Invalid Ticker", "ticker");
            }

        }
        public async Task<decimal> Buy(string Ticker, int Quantity, decimal OriginalPrice)
        {
            if (!_tickers.Contains(Ticker))
            {
                throw new ArgumentException("Invalid Ticker", "ticker");
            }
            if (Quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("quantity", Quantity, "Quantity must be greater than 0.");
            }

            var currentPrice = await GetCurrentPrice(Ticker);

            var Difference = OriginalPrice - currentPrice; // for buy this is positive as original > current

            return Difference * Quantity;
        }
        public async Task<decimal> Sell(string Ticker, int Quantity, decimal OriginalPrice)
        {
            if (!_tickers.Contains(Ticker))
            {
                throw new ArgumentException("Invalid Ticker", "ticker");
            }
            if (Quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("quantity", Quantity, "Quantity must be greater than 0.");
            }

            var currentPrice = await GetCurrentPrice(Ticker);

            var Difference = currentPrice - OriginalPrice; // for sell this is negative as original < current

            return Difference * Quantity;
        }
    }
}
