using FluentValidation.AspNetCore;
using Order.Application.Extensions;
using Order.Infrastructure.Extensions;
using Order.WebApi.Middlewares;

namespace Order.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;
            var configuration = builder.Configuration;

            services.ConfigureDatabase(configuration);

            services.AddTransient<ExceptionHandlerMiddleware>();

            services.AddRepositories();

            services.AddServices();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddValidatorsConfiguration();
            services.AddFluentValidationAutoValidation();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddRouting(options => options.LowercaseUrls = true);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
