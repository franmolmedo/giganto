using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bsd.Cars.Infraestructure.ConnectionString;
using Bsd.Cars.Infraestructure.Context;

namespace Bsd.Cars.Host.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<CarsContext>(options =>
            {
                var connectionStrings = configuration.GetSection<ConnectionStrings>();
                options.UseSqlServer(connectionStrings.DefaultConnection,
                    builder =>
                    {
                        builder.MigrationsAssembly("Bsd.Cars.Infraestructure");
                        builder.UseNetTopologySuite();
                    });
            });
        }
    }
}
