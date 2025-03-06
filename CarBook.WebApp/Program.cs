using CarBook.Application.Interfaces.Services;
using CarBook.Persistence.Filters;
using CarBook.Persistence.Services;
using CarBook.WebApp.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add http client
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

// Add authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.Cookie.Name = "CarBookCookie";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.Cookie.SameSite = SameSiteMode.Strict;
    });


//Force English language for validation messages
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
//Add validators
builder.Services.AddValidatorsFromAssemblyContaining<ValidatorAssemblyMarker>();

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<ISmartBookService, SmartBookService>();

//Add filters
builder.Services.AddScoped(typeof(ValidationFilterAttribute<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapDefaultControllerRoute();

app.Run();
