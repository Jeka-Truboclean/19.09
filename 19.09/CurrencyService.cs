using Microsoft.AspNetCore.SignalR;

namespace _19._09
{
    public class CurrencyService
    {
        private readonly IHubContext<CurrencyHub> _hubContext;
        private Timer _timer;

        public CurrencyService(IHubContext<CurrencyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void StartUpdatingCurrencies()
        {
            _timer = new Timer(UpdateCurrencies, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        private void UpdateCurrencies(object state)
        {
            var random = new Random();
            decimal usdToEur = random.Next(90, 110) / 100.0m; // USD/EUR
            decimal gbpToEur = random.Next(110, 130) / 100.0m; // GBP/EUR

            _hubContext.Clients.All.SendAsync("ReceiveCurrencyUpdate", "USD/EUR", usdToEur);
            _hubContext.Clients.All.SendAsync("ReceiveCurrencyUpdate", "GBP/EUR", gbpToEur);
        }
    }
}
