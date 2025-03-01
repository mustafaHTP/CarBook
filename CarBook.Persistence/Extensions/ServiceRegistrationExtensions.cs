using CarBook.Application.Interfaces;
using CarBook.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
