using Microsoft.OpenApi.Models;

namespace API.Extensions;

public static class SwaggerExtensions
{
    internal static IServiceCollection AddConfigurationSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

            c.AddSecurityDefinition("xAuth", new OpenApiSecurityScheme
            {
                Name = "xAuth",
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Description = "Input value xAuth in header to authorize the request"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "xAuth"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
        return services;
    }

    internal static IServiceCollection AddConfigurationFilterService(this IServiceCollection services)
    {
        services.AddScoped<AuthHeaderFilter>();
        return services;
    }
}