using Catalog.Application.Extensions;
using Catalog.Domain.Extensions;
using Catalog.Persistence.Extensions;
using Catalog.WebApi.Middlewares;
using Microsoft.Extensions.Logging.ApplicationInsights;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Catalog.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;
            var configuration = builder.Configuration;

            services.ConfigureDatabase(configuration);

            builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>("your-category", LogLevel.Trace);
            services.AddTransient<ExceptionHandlerMiddleware>();

            services.AddServices();

            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddApplication();
            services.AddControllers();

            services.AddValidatorsConfiguration();
            services.AddFluentValidationAutoValidation();

            services.AddRouting(options => options.LowercaseUrls = true);

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}