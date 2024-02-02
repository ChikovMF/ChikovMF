using ChikovMF.Application;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Application.Interfaces;
using ChikovMF.Context;
using System.Reflection;

namespace ChikovMF.WebAPI;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IChikovMFContext).Assembly));
        });

        services.AddContext(configuration);
        services.AddApplication(configuration);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void Configure(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
    }
}
