using InventoryPlatform.Application.Common.Interfaces;
using InventoryPlatform.Domain.Identity;
using InventoryPlatform.Infrastructure.Identity;
using InventoryPlatform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InventoryPlatform.Infrastructure.Authentication;
using InventoryPlatform.Infrastructure.Persistence.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<InventoryDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IApplicationDbContext>(
            provider => provider.GetRequiredService<InventoryDbContext>());
        
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        
        services
            .AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<InventoryDbContext>();
        
        services.Configure<JwtOptions>(
            configuration.GetSection(JwtOptions.SectionName));

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        
        return services;
    }
}
