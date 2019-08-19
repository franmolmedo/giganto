using Bsd.Cars.Application.Orders;
using Bsd.Cars.Domain.Shared;
using Bsd.Cars.Infraestructure.ConnectionString;
using Bsd.Cars.Infraestructure.Context;
using Bsd.Cars.Infraestructure.Queries.Shared;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace Bsd.Cars.Api.Configuration
{
    public static class DependencyResolutions
    {
        public static void AddTo(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(GetOrdersRequest).Assembly);            

            var connectionStrings = configuration.GetSection<ConnectionStrings>();
            services.AddScoped<IDbConnection>(x =>
                new SqlConnection(connectionStrings.DefaultConnection));

            services.AddScoped<SqlConnection>(x =>
               new SqlConnection(connectionStrings.DefaultConnection));

            services.Scan(scan =>
                scan.FromAssemblyOf<IQuery>().AddClasses(classes => classes.AssignableTo<IQuery>())
                    .AsImplementedInterfaces().WithScopedLifetime());

            services.Scan(scan =>
                scan.FromAssemblyOf<CarsContext>().AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                    .AsImplementedInterfaces().WithScopedLifetime());
        }
    }
}
