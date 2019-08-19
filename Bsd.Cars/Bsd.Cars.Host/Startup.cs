using Bsd.Cars.Api;
using Bsd.Cars.Host.Extensions;
using Bsd.Cars.Host.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bsd.Cars.Host
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        readonly string AllowedOrigins = "_AllowedOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            ApiConfiguration.ConfigureServices(services, Configuration, Environment);
            services.AddDistributedMemoryCache();
            services.AddOpenApi();

            var origins = new string[] { "http://localhost:4200", "https://localhost:4200", "http://localhost:3000" };
            services.AddCors(options =>
            {
                options.AddPolicy(AllowedOrigins,
                builder =>
                {
                    builder.WithOrigins(origins)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                });
            });

            services.AddEntityFrameworkCore(Configuration)
                .AddCustomDbContext(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(AllowedOrigins)
                .UseUnitOfWork();

            ApiConfiguration.Configure(app, host =>
            {
                host.UseOpenApi();

                return host;
            });
        }

    }
}
