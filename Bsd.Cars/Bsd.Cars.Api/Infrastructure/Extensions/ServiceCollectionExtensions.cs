using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System; 
using Bsd.Cars.Application.Orders;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IMvcCoreBuilder AddFluentValidations(this IMvcCoreBuilder builder) =>
            builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateOrderValidator>());

        public static IServiceCollection AddCustomApiVersioning(this IServiceCollection services)
        {
            return services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });
        }
        public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services,
            IHostingEnvironment environment)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Title = "https://httpstatuses.com/400",
                        Detail = "Please refer to the errors property for additional details."
                    };

                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes =
                        {
                            "application/problem+json",
                            "application/problem+xml"
                        }
                    };
                };
            });

            return services.AddProblemDetails(config =>
            {
                config.IncludeExceptionDetails = ctx => environment.IsDevelopment();

                //Sample exception mapping - Here is the place to map DomainExceptions, NotFoundExceptions, etc.

                config.Map<Exception>((context, ex) =>
                    new ProblemDetails
                    {
                        Title = ex.Message,
                        Status = StatusCodes.Status500InternalServerError,
                        Detail = ex.Message
                    });

                config.Map<NotFoundException>((context, ex) =>
                    new ProblemDetails
                    {
                        Title = ex.Message,
                        Status = StatusCodes.Status400BadRequest,
                        Detail = ex.Message
                    });
            });
        }
    }

    //Sample class that shoud be replaced by the domain exception
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}