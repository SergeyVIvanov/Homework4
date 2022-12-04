using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EntityFramework;

public static class EntityFrameworkInstaller
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DatabaseContext>(options => options
            //.UseLazyLoadingProxies() // lazy loading
            .UseNpgsql(connectionString));

        return services;
    }
}
