using Microsoft.AspNetCore.SignalR.Client;

namespace _19._09_Console_App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/currencyHub")
                .Build();

            connection.On<string, decimal>("ReceiveCurrencyUpdate", (currency, rate) =>
            {
                Console.WriteLine($"{currency}: {rate}");
            });

            await connection.StartAsync();
            Console.WriteLine("Connected to SignalR.");

            Console.ReadLine();
            await connection.StopAsync();
        }
    }
}
