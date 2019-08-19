using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Bsd.Cars.Infraestructure.Context;

namespace Bsd.Cars.Host.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost MigrateDbContext(this IWebHost webHost, Action<CarsContext> initializer)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<CarsContext>();

                try
                {
                    initializer(context);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<CarsContext>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            return webHost;
        }
    }
}
