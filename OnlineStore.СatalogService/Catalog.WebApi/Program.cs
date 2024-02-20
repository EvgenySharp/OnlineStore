using Catalog.Application.Extensions;
using Catalog.Persistence.Extensions;
using Catalog.WebApi.Middlewares;

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

            services.AddTransient<ExceptionHandlerMiddleware>();

            services.AddRepositories();

            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddApplication();
            services.AddControllers().AddNewtonsoftJson();

            services.AddValidatorsConfiguration();

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