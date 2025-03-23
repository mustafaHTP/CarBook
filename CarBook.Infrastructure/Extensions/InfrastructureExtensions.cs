using CarBook.Application.Interfaces.Services;
using CarBook.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            AddServices(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IApiService, ApiService>();
            services.AddScoped<ISmartBookService, SmartBookService>();
        }
    }
}
