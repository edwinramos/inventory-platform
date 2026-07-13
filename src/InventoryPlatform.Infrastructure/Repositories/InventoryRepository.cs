using InventoryPlatform.Application.Common.Interfaces;
using InventoryPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryPlatform.Infrastructure.Persistence.Repositories;

public sealed class InventoryRepository : IInventoryRepository
{
    private readonly InventoryDbContext _context;

    public InventoryRepository(InventoryDbContext context)
    {
        _context = context;
    }


    public async Task<InventoryItem?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        return await _context.InventoryItems
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.ProductId == productId,
                cancellationToken);
    }

    public async Task AddAsync(InventoryItem inventoryItem, CancellationToken cancellationToken = default)
    {
        await _context.InventoryItems.AddAsync(inventoryItem, cancellationToken);
    }
    
    public async Task AddMovementAsync(InventoryMovement inventoryMovement, CancellationToken cancellationToken = default)
    {
        await _context.InventoryMovements.AddAsync(inventoryMovement, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
