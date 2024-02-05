using Auth.BuisnessLayer.Abstractions.Interfaces;
using Auth.BuisnessLayer.Services;
using Auth.DataAccessLayer;
using Auth.DataAccessLayer.Entity;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Auth.BuisnessLayer.Extensions;
using Auth.WebApi.Middlewares;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(connectionString, dbContext => dbContext.MigrationsAssembly("Auth.DataAccessLayer")));

            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders();

            builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>("your-category", LogLevel.Trace);

            services.AddScoped<ExceptionHandlerMiddleware>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();


            builder.Services.AddMvc(options =>
            {
                options.Filters.Add(typeof(RequestDataValidationAttribute));
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

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