using Microsoft.AspNetCore.SignalR;

namespace _19._09
{
    public class CurrencyHub : Hub
    {
        public async Task SendCurrencyUpdate(string currency, decimal rate)
        {
            await Clients.All.SendAsync("ReceiveCurrencyUpdate", currency, rate);
        }
    }
}
