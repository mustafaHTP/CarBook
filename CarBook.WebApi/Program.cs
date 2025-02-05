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

//add db context
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICarReservationPricingRepository, CarReservationPricingRepository>();

//Add About handlers
builder.Services.AddScoped<GetAboutsQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<DeleteAboutCommandHandler>();
//Add Banner handlers
builder.Services.AddScoped<GetBannersQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<DeleteBannerCommandHandler>();
//Add Brand handlers
builder.Services.AddScoped<GetBrandsQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<DeleteBrandCommandHandler>();
//Add BlogCategory handlers
builder.Services.AddScoped<GetBlogCategoriesQueryHandler>();
builder.Services.AddScoped<GetBlogCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateBlogCategoryCommandHandler>();
builder.Services.AddScoped<UpdateBlogCategoryCommandHandler>();
builder.Services.AddScoped<DeleteBlogCategoryCommandHandler>();
//Add Car handlers
builder.Services.AddScoped<GetCarsQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<DeleteCarCommandHandler>();
//Add Contact handlers
builder.Services.AddScoped<GetContactsQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<DeleteContactCommandHandler>();

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
