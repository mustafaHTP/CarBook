using CarBook.Application;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Application.Interfaces.Services;
using CarBook.Application.Validators;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Globalization;
using System.Text;

namespace CarBook.Persistence.Extensions
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

        public static void AddServicesApi(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IApiService, ApiService>();
        }

        public static void AddServicesApp(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IApiService, ApiService>();
            services.AddScoped<ISmartBookService, SmartBookService>();
        }

        public static void AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyMarker>());
        }

        public static void AddApplicationDbContext(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
        }

        public static void AddFluentValidationApi(this IServiceCollection services)
        {
            //Force English language for validation messages
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
            //Add validators
            services.AddValidatorsFromAssemblyContaining<ValidatorAssemblyMarker>();
            //Add auto validation
            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableBuiltInModelValidation = true;
            });
        }

        public static void AddFluentValidationApp(this IServiceCollection services)
        {
            //Force English language for validation messages
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
            //Add validators
            services.AddValidatorsFromAssemblyContaining<ValidatorAssemblyMarker>();
        }

        public static void AddJwtAuthenticationApi(this IServiceCollection services, IConfiguration configuration)
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

        public static void AddJwtAuthenticationApp(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.LogoutPath = "/Auth/Logout";
                    options.AccessDeniedPath = "/Auth/AccessDenied";
                    options.Cookie.Name = "CarBookCookie";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                    options.Cookie.SameSite = SameSiteMode.Strict;
                });
        }
    }
}
