using Microsoft.OpenApi;

namespace RestWithASPNET10Erudio.Rest.Configuration;

public static class SwaggerConfig
{
    private static readonly string AppName =
        "ASP.NET Core 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker and Kubernetes";

    private static readonly string AppDescrition = $"REST API RESTfull developed in course {AppName}";

    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = AppName,
                Version = "v1",
                Description = AppDescrition,
                Contact = new OpenApiContact
                {
                    Name = "Erudio",
                    Email = "giovanniadev@gmail.com",
                    Url = new Uri("https://pub.edudio.com.br/meus-cursos"),
                },
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://pub.edudio.com.br/meus-cursos"),
                }
            });
            c.CustomSchemaIds(type => type.FullName);
        });
        return services;
    }

    public static IApplicationBuilder UseSwaggerSpacification(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            c.RoutePrefix = "swagger-ui";
            c.DocumentTitle = AppName;
        });
        return app;
    }
    
}