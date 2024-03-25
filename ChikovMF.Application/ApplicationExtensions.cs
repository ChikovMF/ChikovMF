using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Application.Features.Authorization;
using ChikovMF.Application.Features.Files.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Telegram.Bot;

namespace ChikovMF.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration, IFileManager fileManager)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        var authConfiguration = configuration.GetSection("AuthConfiguration").Get<AuthConfiguration>();
        if (authConfiguration is null)
        {
            throw new ArgumentNullException("Configuration string not found for AuthService.");
        }
        services.AddSingleton(authConfiguration);
        string accessToken = configuration["AuthConfiguration:AccessToken"] ?? throw new ArgumentNullException("Access token string not found for AuthService.");
        services.AddScoped(s => new TelegramBotClient(accessToken));

        return services;
    }
}
