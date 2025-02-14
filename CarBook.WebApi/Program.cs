using CarBook.Application.Features.AboutFeatures.Handlers;
using CarBook.Application.Features.BannerFeatures.Handlers;
using CarBook.Application.Features.BlogFeatures.Handlers;
using CarBook.Application.Features.BrandFeatures.Handlers;
using CarBook.Application.Features.CarFeatures.Handlers;
using CarBook.Application.Features.ContactFeatures.Handlers;
using CarBook.Application.Interfaces;
using CarBook.Application.Services;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Resolve circular references between entities

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.MaxDepth = 64;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add db context
builder.Services.AddScoped<ApplicationDbContext>();

//Add repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICarReservationPricingRepository, CarReservationPricingRepository>();
builder.Services.AddScoped<IBlogTagCloudRepository, BlogTagCloudRepository>();
builder.Services.AddScoped<IBlogTagRepository, BlogTagRepository>();
builder.Services.AddScoped<IBlogCommentRepository, BlogCommentRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();

//Add application services
builder.Services.AddApplicationService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
