using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.SignalR.Extensions
{
    public static class SignalRExtensions
    {
        public static void AddSignalRLayer(this IServiceCollection services)
        {
            AddMediatRService(services);
            AddSignalRService(services);
        }

        private static void AddSignalRService(this IServiceCollection services)
        {
            services.AddSignalR();
        }

        private static void AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                {
                    config.RegisterServicesFromAssemblyContaining<SignalRAssemblyMarker>();
                }
            );
        }
    }
}
