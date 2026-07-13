using InventoryPlatform.Domain.Entities;

public interface IInventoryRepository
{
    Task<InventoryItem?> GetByProductIdAsync(
        Guid productId,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        InventoryItem inventoryItem,
        CancellationToken cancellationToken = default);
    
    Task AddMovementAsync(
        InventoryMovement inventoryMovement,
        CancellationToken cancellationToken = default);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
}
