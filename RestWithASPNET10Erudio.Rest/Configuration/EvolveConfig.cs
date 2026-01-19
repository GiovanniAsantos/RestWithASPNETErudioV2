using EvolveDb;
using Serilog;

namespace RestWithASPNET10Erudio.Rest.Configuration;

public static class EvolveConfig
{
    public static IServiceCollection AddEvolve(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }
        }

        try
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            using var evolveConnection = new Npgsql.NpgsqlConnection(connectionString);
            var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
            {
                Locations = new[] { "db/migrations", "db/dataset" },
                IsEraseDisabled = true,
            };
            evolve.Migrate();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while migrating the database");
            throw;
        }

        return services;
    }
}