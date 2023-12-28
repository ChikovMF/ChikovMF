using ChikovMF.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChikovMF.Persistence;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<ChikovMFDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IChikovMFDbContext>(provider =>
            provider.GetService<ChikovMFDbContext>() ?? 
                throw new NullReferenceException(
                    $"The {nameof(ChikovMFDbContext)} service is not connected to the project.")
                );

        return services;
    }
}
