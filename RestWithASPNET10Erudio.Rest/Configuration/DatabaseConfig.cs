using Microsoft.EntityFrameworkCore;
using RestWithASPNET10Erudio.Rest.Model.Context;

namespace RestWithASPNET10Erudio.Rest.Configuration;

public static class DatabaseConfig
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("Connection string 'DefaultConnection' not found.");
        }

        services.AddDbContext<PostgresContext>(options => options.UseNpgsql(connectionString));
        return services;
    }
}