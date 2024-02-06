using Auth.DataAccessLayer.Extensions;
using Auth.BuisnessLayer.Extensions;
using Auth.WebApi.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Logging.ApplicationInsights;

namespace Auth.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;
            var configuration = builder.Configuration;

            services.ConfigureDatabase(configuration);
            services.ConfigureIdentity();

            builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>("your-category", LogLevel.Trace);
            
            services.AddScoped<ExceptionHandlerMiddleware>();

            services.AddServices();
            services.ConfigureAuthentication(configuration);

            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            services.AddValidatorsConfiguration();
            services.AddFluentValidationAutoValidation();

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