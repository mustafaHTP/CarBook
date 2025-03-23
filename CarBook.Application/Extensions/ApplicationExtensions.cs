using CarBook.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            AddMediatRService(services);
            AddFluentValidation(services);
        }

        private static void AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                {
                    config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyMarker>();
                }
            );
        }

        private static void AddFluentValidation(this IServiceCollection services)
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
    }
}
