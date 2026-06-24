using ManufacturingOffice.Application.Interfaces;
using ManufacturingOffice.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ManufacturingOffice.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Register repositories
        services.AddSingleton<IWorkOrderRepository, InMemoryWorkOrderRepository>();
        services.AddSingleton<IInventoryRepository, InMemoryInventoryRepository>();

        return services;
    }
}
