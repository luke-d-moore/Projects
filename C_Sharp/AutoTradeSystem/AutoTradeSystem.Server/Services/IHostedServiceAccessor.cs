namespace AutoTradeSystem.Server.Services
{
    public interface IHostedServiceAccessor<out T> where T : IHostedService
    {
        T Service { get; }
    }
}