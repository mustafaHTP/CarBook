using CarBook.Persistence.Extensions;
using CarBook.WebApp.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add http client
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddJwtAuthenticationApp();

builder.Services.AddFluentValidationApp();

builder.Services.AddServicesApp();

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
