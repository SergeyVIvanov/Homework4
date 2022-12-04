using AutoMapper;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Abstractions;
using Infrastructure.Repositories.Implementations;
using Services.Abstractions;
using Services.Implementations;
using WebApi.Mappings;
using WebApi.Settings;

namespace WebApi;

public static class Startup
{
    public static WebApplication ConfigureMiddlewarePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }

    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        AddMapper(builder.Services);
        AddDbContext(builder);
        InstallServices(builder.Services);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    private static void AddDbContext(WebApplicationBuilder builder)
    {
        AppSettings appSettings = builder.Configuration.Get<AppSettings>();
        string connectionString = appSettings.ConnectionString ??
            throw new InvalidOperationException($"Connection string '{nameof(appSettings.ConnectionString)}' not found.");
        builder.Services.ConfigureDbContext(connectionString);
    }

    private static IServiceCollection AddMapper(IServiceCollection services)
    {
        services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        return services;
    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CustomerMappingProfile>();
            cfg.AddProfile<Services.Implementations.Mappings.CustomerMappingProfile>();
        });
        configuration.AssertConfigurationIsValid();
        return configuration;
    }

    private static IServiceCollection InstallServices(IServiceCollection services)
    {
        services
            .AddTransient<ICustomerRepository, CustomerRepository>()
            .AddTransient<ICustomerService, CustomerService>();

        return services;
    }
}
