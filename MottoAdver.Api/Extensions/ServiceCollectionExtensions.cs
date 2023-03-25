using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MotoAdd.Application.Services;
using MotoAdd.Infastructure.Repositories;
using MotoAddver.Application.Services;
using MottoAdver.Application.Services;
using MottoAdver.Infastructure.Authentications;
using MottoAdver.Infastructure.DbContexts;
using System.Text;

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

        services.Configure<JwtOption>(configuration.GetSection("JwtSettings"));

        services.AddSwaggerService();
        
        return services;
    }

    public static IServiceCollection AddApplications(
        this IServiceCollection services)
    {
        services.AddScoped<IAddressService, AddressService>();

        services.AddScoped<IAddvertisementService, AddvertisementService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IMotoService, MotoService>();

        services.AddScoped<IAuthenticationServices, AuthenticationServices>();

        return services;
    }

    public static IServiceCollection AddInfastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IAddressRepository, AddressRepository>();

        services.AddScoped<IAdminRepository, AdminRepository>();

        services.AddScoped<IMotoRepository, MotoRepository>();

        services.AddScoped<IAddvertisementRepository, AddvertisementRepository>();

        services.AddScoped<IGeneratePassword, GeneratePassword>();

        services.AddScoped<IGenerateJwtToken, GenerateJwtToken>();

        return services;
    }

    public static IServiceCollection AutentificationService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("UserPolicy",
                options =>  options.RequireRole("Admin"));
        });


        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        
        return services;
    }

    private static void AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "MotoAdd.Api", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
    }
}
