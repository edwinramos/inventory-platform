using InventoryPlatform.Application.Common.Interfaces;
using InventoryPlatform.Domain.Entities;
using InventoryPlatform.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryPlatform.Infrastructure.Persistence;

public class InventoryDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public DbSet<Product> Products => Set<Product>();
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(InventoryDbContext).Assembly);
    }
}
