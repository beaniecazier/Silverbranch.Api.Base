using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Gay.Silverbranch.Api.Utilities.Backend.Swagger;

#pragma warning disable CS1591

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    private readonly IHostEnvironment _environment;

    public static string ContactName = "Unassigned Value";
    public static string ContactUrl = "Unassigned Value";
    public static string ContactEmail = "Unassigned Value";
    public static string TermsOfServiceUrl = "Unassigned Value";

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IHostEnvironment environment)
    {
        _provider = provider;
        _environment = environment;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                new OpenApiInfo
                {
                    Title = _environment.ApplicationName,
                    Version = description.ApiVersion.ToString(),
                    Description = "Scafffolder API Version Documentation",
                    Contact = new OpenApiContact
                    {
                        Name = ContactEmail,
                        Url = new Uri(ContactUrl),
                        Email = ContactEmail,
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://mit-license.org/")
                    },
                    TermsOfService = new Uri(TermsOfServiceUrl),
                });
        }
    }
}

#pragma warning restore CS1591