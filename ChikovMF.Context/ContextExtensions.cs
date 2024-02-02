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

        return services;
    }
}
