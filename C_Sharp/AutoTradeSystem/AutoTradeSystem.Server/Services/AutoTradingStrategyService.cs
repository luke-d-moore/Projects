using AutoTradeSystem.Server.Dtos;
using System.Collections.Concurrent;

namespace AutoTradeSystem.Server.Services
{
    internal class AutoTradingStrategyService : ServiceBase, IAutoTradingStrategyService
    {
        private const int CheckRateMilliseconds = 60000;
        private readonly ILogger<AutoTradingStrategyService> _logger;
        private readonly IDictionary<string, TradingStrategy> _Strategies = new ConcurrentDictionary<string, TradingStrategy>();
        private readonly object _CheckStrategiesLock = new object();
        private readonly IPricingService _pricingService;

        public AutoTradingStrategyService(ILogger<AutoTradingStrategyService> logger, IPricingService pricingService)
            : base(CheckRateMilliseconds, logger)
        {
            _logger = logger;
            _pricingService = pricingService;
        }
        public IDictionary<string, TradingStrategy> GetStrategies()
        {
            return _Strategies;
        }

        public async Task<bool> AddStrategy(TradingStrategyDto tradingStrategy)
        {
            var actionPrice = await GetActionPrice(tradingStrategy);

            if (actionPrice.ActionPrice == null || actionPrice.OriginalPrice == null)
            {
                return false;
            }

            var id = Guid.NewGuid().ToString();

            var strategy = new TradingStrategy(actionPrice.ActionPrice.Value, tradingStrategy, actionPrice.OriginalPrice.Value);

            var added = _Strategies.TryAdd(
                id,
                strategy
                );

            if (added)
            {
                _logger.LogInformation("Strategy Added Successfully {0}", id);
            }
            else
            {
                _logger.LogError("Failed to Add Strategy {@strategy}", strategy);
            }

            return added;
        }

        private async Task<(decimal? ActionPrice, decimal? OriginalPrice)> GetActionPrice(TradingStrategyDto tradingStrategy)
        {
            //we need to keep a record of the price that we will action the strategy
            //PriceMovement is a percentage
            //if Buy then % is a decrease
            //if Sell then % is an increase

            decimal movement =
                tradingStrategy.TradeAction == TradeAction.Sell ?
                tradingStrategy.PriceChange :
                -tradingStrategy.PriceChange;

            decimal multiplyfactor = (100 + movement) / 100.0m;

            decimal? quote = await GetCurrentPrice(tradingStrategy.Ticker);

            if(quote == null) return (null, null);

            return (quote * multiplyfactor, quote);
        }

        private async Task<decimal?> GetCurrentPrice(string ticker)
        {
            //we need to keep a record of the price that we will action the strategy
            //PriceMovement is a percentage
            //if Buy then % is a decrease
            //if Sell then % is an increase

            decimal quote;

            try
            {
                quote = await _pricingService.GetCurrentPrice(ticker);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Invalid Ticker {0}", ticker);
                return null;
            }

            return quote;
        }
        public async Task<bool> RemoveStrategy(string ID)
        {
            await Task.Delay(100);
            var removed =_Strategies.Remove(ID);

            if (removed)
            {
                _logger.LogInformation("Strategy Removed Successfully {0}", ID);
            }
            else
            {
                _logger.LogError("Failed to Add Strategy {0}", ID);
            }

            return removed; 
        }

        private void RemoveStrategies(IList<string> IdsToRemove)
        {
            foreach(var id in IdsToRemove)
            {
                if (_Strategies.Remove(id))
                {
                    _logger.LogInformation("Removed Stretegy Successfully {0}", id);
                }
                else
                {
                    _logger.LogError("Failed to Remove Stretegy {0}", id);
                }
            }
        }
        protected async override Task<int> CheckTradingStrategies()
        {
            await Task.Delay(100);

            lock (_CheckStrategiesLock)
            {
                var IDsToRemove = new List<string>();

                foreach(var strategy in _Strategies)
                {

                    var currentPrice = Task.Run(async () => await GetCurrentPrice(strategy.Value.TradingStrategyDto.Ticker)).Result;

                    if(currentPrice == null)
                    {
                        _logger.LogInformation("Failed to get current price for {0}", strategy.Value.TradingStrategyDto.Ticker);
                        continue;
                    }

                    if (currentPrice.Value >= strategy.Value.ActionPrice && strategy.Value.TradingStrategyDto.TradeAction == TradeAction.Sell)
                    {
                        try
                        {
                            var profit = Task.Run(async () => await _pricingService.Sell(strategy.Value.TradingStrategyDto.Ticker, strategy.Value.TradingStrategyDto.Quantity, strategy.Value.OriginalPrice)).Result;
                            IDsToRemove.Add(strategy.Key);
                            continue;
                        }
                        catch(Exception ex)
                        {
                            _logger.LogInformation("Failed to Execute Strategy for {@strategy}", strategy);
                        }
                    }

                    if (currentPrice.Value <= strategy.Value.ActionPrice && strategy.Value.TradingStrategyDto.TradeAction == TradeAction.Buy)
                    {
                        try
                        {
                            var profit = Task.Run(async () => await _pricingService.Buy(strategy.Value.TradingStrategyDto.Ticker, strategy.Value.TradingStrategyDto.Quantity, strategy.Value.OriginalPrice)).Result;
                            IDsToRemove.Add(strategy.Key);
                            continue;
                        }
                        catch (Exception ex)
                        {
                            _logger.LogInformation("Failed to Execute Strategy for {@strategy}", strategy);
                        }
                    }
                }

                RemoveStrategies(IDsToRemove);
            }

            return 0;
        }
    }
}
