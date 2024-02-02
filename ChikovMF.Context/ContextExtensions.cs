using ChikovMF.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChikovMF.Context;

public static class ContextExtensions
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ChikovMFContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
        });

        services.AddScoped<IChikovMFContext>(provider =>
            provider.GetService<ChikovMFContext>() ??
                throw new NullReferenceException(
                    $"The {nameof(ChikovMFContext)} service is not connected to the project.")
                );

        return services;
    }
}
