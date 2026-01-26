using Microsoft.OpenApi;

namespace RestWithASPNET10Erudio.Rest.Configuration;

public static class OpenAPIConfig
{
    private static readonly string AppName =
        "ASP.NET Core 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker and Kubernetes";

    private static readonly string AppDescrition = $"REST API RESTfull developed in course {AppName}";

    public static IServiceCollection AddOpenAPIConfig(this IServiceCollection services)
    {
        services.AddSingleton(new OpenApiInfo()
        {
            Title = AppName,
            Version = "v1",
            Description = AppDescrition,
            Contact = new OpenApiContact
            {
                Name = "Erudio",
                Url = new Uri("https://pub.edudio.com.br/meus-cursos"),
            },
            License = new OpenApiLicense
            {
                Name = "MIT",
                Url = new Uri("https://pub.edudio.com.br/meus-cursos"),
            }
        });
        return services;
    }
}