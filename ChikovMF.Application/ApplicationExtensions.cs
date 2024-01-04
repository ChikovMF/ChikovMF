using ChikovMF.WebApi.Services.EmailService;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace ChikovMF.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Добавленме конфигурации EmailConfiguration для EmailSender.
        var emailConfig = configuration.GetSection("EmailConfiguration")?.Get<EmailConfiguration>();
        if (emailConfig is null)
        {
            throw new ArgumentNullException("Configuration string not found for EmailService.");
        }
        services.AddSingleton(emailConfig);

        services.AddSingleton<IEmailSender, EmailSender>();
        return services;
    }
}
