using CarBook.Application;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Application.Interfaces.Services;
using CarBook.Application.Validators;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Services;
using CarBook.SignalR;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace CarBook.WebApi.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICarReservationPricingRepository, CarReservationPricingRepository>();
            services.AddScoped<IBlogTagCloudRepository, BlogTagCloudRepository>();
            services.AddScoped<IBlogTagRepository, BlogTagRepository>();
            services.AddScoped<IBlogCommentRepository, BlogCommentRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IBlogAuthorRepository, BlogAuthorRepository>();
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            services.AddScoped<IRentalCarRepository, RentalCarRepository>();
            services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
            services.AddScoped<ICarReviewRepository, CarReviewRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IApiService, ApiService>();
        }

        public static void AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyMarker>();
                config.RegisterServicesFromAssemblyContaining<SignalRAssemblyMarker>();
            }
            );
        }

        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration["ConnectionString"];
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("Connection string is missing in user-secrets\n" +
                        "dotnet user-secrets set \"ConnectionString\" \"your_connection_string\"");
                }
                options.UseSqlServer(connectionString);
            });
        }

        public static void AddFluentValidation(this IServiceCollection services)
        {
            //Force English language for validation messages
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
            //Add validators
            services.AddValidatorsFromAssemblyContaining<ValidatorAssemblyMarker>();
            //Add auto validation
            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableBuiltInModelValidation = true;
                config.OverrideDefaultResultFactoryWith<CustomResultFactory>();
            });
        }

        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");

            // Check if jwtSettings is null or if required values are missing
            if (jwtSettings == null || !jwtSettings.Exists())
            {
                throw new Exception("Jwt settings are missing or invalid in appsettings.json");
            }

            var jwtKey = jwtSettings["Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new Exception("Jwt key is missing in appsettings.json");
            }

            var jwtIssuer = jwtSettings["Issuer"];
            var jwtAudience = jwtSettings["Audience"];

            if (string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
            {
                throw new Exception("Jwt Issuer or Audience is missing in appsettings.json");
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidAudience = jwtSettings["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    };
                });
        }
    }
}
