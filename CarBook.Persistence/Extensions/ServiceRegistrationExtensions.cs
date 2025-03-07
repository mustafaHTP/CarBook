using CarBook.Application;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

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

        public static void AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyMarker>());
        }
    }
}
