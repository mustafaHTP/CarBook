using CarBook.Application.Features.AboutFeatures.Handlers;
using CarBook.Application.Features.BannerFeatures.Handlers;
using CarBook.Application.Features.BlogFeatures.Handlers;
using CarBook.Application.Features.BrandFeatures.Handlers;
using CarBook.Application.Features.CarFeatures.Handlers;
using CarBook.Application.Features.ContactFeatures.Handlers;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add db context
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();

//Add About handlers
builder.Services.AddScoped<GetAllAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<DeleteAboutCommandHandler>();
//Add Banner handlers
builder.Services.AddScoped<GetAllBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<DeleteBannerCommandHandler>();
//Add Brand handlers
builder.Services.AddScoped<GetAllBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<DeleteBrandCommandHandler>();
//Add BlogCategory handlers
builder.Services.AddScoped<GetAllBlogCategoriesQueryHandler>();
builder.Services.AddScoped<GetBlogCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateBlogCategoryCommandHandler>();
builder.Services.AddScoped<UpdateBlogCategoryCommandHandler>();
builder.Services.AddScoped<DeleteBlogCategoryCommandHandler>();
//Add Car handlers
builder.Services.AddScoped<GetAllCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<DeleteCarCommandHandler>();
builder.Services.AddScoped<GetAllCarsWithBrandQueryHandler>();
//Add Contact handlers
builder.Services.AddScoped<GetAllContactsQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<DeleteContactCommandHandler>();

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
