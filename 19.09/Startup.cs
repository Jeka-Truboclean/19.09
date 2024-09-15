using _19._09;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSignalR();
        services.AddSingleton<CurrencyService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CurrencyService currencyService)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<CurrencyHub>("/currencyHub");
        });

        currencyService.StartUpdatingCurrencies();
    }
}
