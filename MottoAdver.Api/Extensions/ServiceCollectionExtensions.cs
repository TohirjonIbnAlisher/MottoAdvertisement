using Microsoft.EntityFrameworkCore;
using MotoAdd.Application.Services;
using MotoAdd.Infastructure.Repositories;
using MottoAdver.Application.Services;
using MottoAdver.Infastructure.DbContexts;

namespace MottoAdver.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMottoAdverDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServerConnection");

        services.AddDbContextPool<MottoAdverContext>(option =>
        {
            option.UseSqlServer(connectionString, sqlServerOption =>
            {
                sqlServerOption.EnableRetryOnFailure();
            });
        });
        
        return services;
    }

    public static IServiceCollection AddApplications(
        this IServiceCollection services)
    {
        services.AddScoped<IAddressService, AddressService>();

        services.AddScoped<IAddvertisementService, AddvertisementService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IMotoService, MotoService>();

        return services;
    }

    public static IServiceCollection AddInfastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IAddressRepository, AddressRepository>();

        services.AddScoped<IAdminRepository, AdminRepository>();

        services.AddScoped<IMotoRepository, MotoRepository>();

        services.AddScoped<IAddvertisementRepository, AddvertisementRepository>();

        return services;
    }
}
