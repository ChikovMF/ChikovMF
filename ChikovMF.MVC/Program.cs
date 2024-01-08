using ChikovMF.Application;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Application.Interfaces;
using ChikovMF.Persistence;
using ChikovMF.WebApi.Services.EmailService;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Подключение и конфигурация AutoMapper.
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IChikovMFDbContext).Assembly));
});

// Подключение слоя "Persistence".
string stringConnection = builder.Configuration.GetConnectionString("DbConnection") ??
    throw new NullReferenceException("The database connection string was not found.");
builder.Services.AddPersistence(stringConnection);

// Куки
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.LoginPath = new PathString("/AccessDenied");
        options.AccessDeniedPath = new PathString("/AccessDenied");
    });

// Подключение слоя "Application".
builder.Services.AddApplication(configuration);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();    // аутентификация
app.UseAuthorization();     // авторизация

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
