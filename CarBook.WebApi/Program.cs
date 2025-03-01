using CarBook.Application.Interfaces;
using CarBook.Application.Services;
using CarBook.Application.Validators;
using CarBook.Application.Validators.CarReviewValidators;
using CarBook.Persistence.Context;
using CarBook.Persistence.Extensions;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Resolve circular references between entities
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.MaxDepth = 64;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add db context
builder.Services.AddScoped<ApplicationDbContext>();

//Add repositories
builder.Services.AddRepositories();

//Add Services
builder.Services.AddScoped<IJwtService, JwtService>();

//Add application services
builder.Services.AddApplicationService();

//Force English language for validation messages
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
//Add validators
builder.Services.AddValidatorsFromAssemblyContaining<ValidatorAssemblyMarker>();
//Add auto validation
builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableBuiltInModelValidation = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:7060")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});


var jwtSettings = builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
