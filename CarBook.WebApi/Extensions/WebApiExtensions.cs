using CarBook.Application;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Application.Interfaces.Services;
using CarBook.Application.Validators;
using CarBook.SignalR;
using CarBook.WebApi.Filters;
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
    public static class WebApiExtensions
    {
        public static void AddFilters(this IServiceCollection services)
        {
            services.AddScoped(typeof(NotFoundFilterAttribute<>));
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
