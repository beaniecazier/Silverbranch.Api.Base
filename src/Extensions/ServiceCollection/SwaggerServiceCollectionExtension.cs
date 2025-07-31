using System.Reflection;
using Gay.Silverbranch.Api.Utilities.Backend.Swagger;
using Gay.Silverbranch.Api.Utilities.Backend.Swagger.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Gay.Silverbranch.Api.Utilities.Backend.Extensions.ServiceCollection;

#pragma warning disable CS1591

public static class SwaggerServiceCollectionExtension
{
    public static IServiceCollection ConfigureAndAddSwagger(this IServiceCollection services, ConfigurationManager config)
    {
        var host = config["Keycloak:auth-server-url"];
        var realm = config["Keycloak:realm"];
        var wellKnownUrl = new Uri($"{host}/realms/{realm}/.well-known/openid-configuration");
        
        // var keycloakScopes = new Dictionary<string, string>
        // {
        //     { "openid", "openid" },
        //     { "profile", "profile" }
        // };
        // var keycloakFlow = new OpenApiOAuthFlow
        // { 
        //     AuthorizationUrl = new Uri(authURL),
        //     Scopes = keycloakScopes
        // };
        // var oauthFlows = new OpenApiOAuthFlows { Implicit = keycloakFlow };
        var apiSecurityScheme = new OpenApiSecurityScheme
        {
            Name = "Keycloak",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.OpenIdConnect,
            OpenIdConnectUrl = wellKnownUrl, 
            Scheme = "bearer",
            BearerFormat = "JWT",
            Reference = new OpenApiReference()
            {
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme,
            }
        };
        
        //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlFilename = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
        
        var securityRequirement = MakeNewOpenApiSecurityRequirement(apiSecurityScheme);
        
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        
        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();
            options.OperationFilter<SwaggerDefaultValues>();
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            options.AddSecurityDefinition(apiSecurityScheme.Reference.Id, apiSecurityScheme);
            options.AddSecurityRequirement(securityRequirement);
        });

        return services;
    }

    private static OpenApiSecurityRequirement MakeNewOpenApiSecurityRequirement(OpenApiSecurityScheme apiSecurityScheme)
    {
        // var reference = new OpenApiReference
        // {
        //     Id = "Keycloak",
        //     Type = ReferenceType.SecurityScheme,
        // };
        //
        // var securityScheme = new OpenApiSecurityScheme
        // {
        //     Reference = reference,
        //     In = ParameterLocation.Header,
        //     Name = "Bearer",
        //     Scheme = "Bearer",
        // };

        return new OpenApiSecurityRequirement
        {
            {
                apiSecurityScheme,
                []
            }
        };
    }
}

#pragma warning restore CS1591