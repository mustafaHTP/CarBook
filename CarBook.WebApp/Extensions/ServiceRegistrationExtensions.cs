using CarBook.Application.Interfaces.Services;
using CarBook.Infrastructure.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Globalization;
using System.Reflection;

namespace CarBook.WebApp.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IApiService, ApiService>();
            services.AddScoped<ISmartBookService, SmartBookService>();
        }

        public static void AddFluentValidation(this IServiceCollection services)
        {
            //Force English language for validation messages
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
            //Add validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public static void AddJwtAuthentication(this IServiceCollection services)
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
