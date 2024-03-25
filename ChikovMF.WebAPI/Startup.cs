using ChikovMF.Application;
using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Context;
using ChikovMF.WebAPI.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace ChikovMF.WebAPI;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtAuth:Issuer"],
                    ValidAudience = configuration["JwtAuth:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtAuth:Key"] ?? throw new ArgumentNullException("JwtAuth:Key string not found.")))
                };
            });

        services.AddControllers();

        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IChikovMFContext).Assembly));
        });

        services.AddScoped<IFileManager, StaticFileManager>();

        services.AddContext(configuration);
        services.AddApplication(configuration, new StaticFileManager());

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(option =>
        {
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });
    }

    public static void Configure(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();

        string pathImageDirectory = Path.Combine(Directory.GetCurrentDirectory(), $"Images");
        if (!Directory.Exists(pathImageDirectory))
        {
            Directory.CreateDirectory(pathImageDirectory);
        }
        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
            RequestPath = new PathString("/Images")
        });

        string pathFileDirectory = Path.Combine(Directory.GetCurrentDirectory(), $"Files");
        if (!Directory.Exists(pathFileDirectory))
        {
            Directory.CreateDirectory(pathFileDirectory);
        }
        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
            RequestPath = new PathString("/Files")
        });

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        if (env.IsDevelopment())
        {
            app.UseCors();
        }

        app.UseAuthentication();
        app.UseAuthorization();
    }
}
