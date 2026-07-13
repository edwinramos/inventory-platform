using InventoryPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryPlatform.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; }
    DbSet<InventoryItem> InventoryItems { get; }
    DbSet<InventoryMovement> InventoryMovements { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}
