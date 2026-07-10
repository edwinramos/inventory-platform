using InventoryPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryPlatform.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}
