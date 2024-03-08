using CarRental.Application.Interfaces.Stores;
using CarRental.Infraestructure.Persistence;
using CarRental.Infraestructure.Persistence.Stores;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default"),
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddStores();

        return services;
    }

    private static IServiceCollection AddStores(this IServiceCollection services)
    {
        services.AddScoped<ILocationStore, LocationStore>();
        services.AddScoped<IRentalStore, RentalStore>();
        services.AddScoped<IVehicleStore, VehicleStore>();

        return services;
    }
}