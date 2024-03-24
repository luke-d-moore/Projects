namespace AutoTradeSystem.Server.Services
{
    public abstract class ServiceBase : BackgroundService
    {

        private readonly int _checkRate;

        private readonly ILogger<ServiceBase> _logger;

        protected ServiceBase(int checkRate, ILogger<ServiceBase> logger)
        {
            _checkRate = checkRate;
            _logger = logger;
        }

        protected sealed override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Automatic Trade System Service is starting.");
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await CheckTradingStrategies().ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, "An exception occurred");
                    throw;
                }

                await Task.Delay(_checkRate, cancellationToken).ConfigureAwait(false);
            }

            _logger.LogInformation("Automatic Trade System Service is stopping.");
        }

        protected abstract Task CheckTradingStrategies();
    }
}
