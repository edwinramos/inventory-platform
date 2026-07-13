using InventoryPlatform.Application.Common.Interfaces;
using InventoryPlatform.Domain.Entities;
using MediatR;

namespace InventoryPlatform.Application.Features.Inventory.RemoveStock;

public sealed class RemoveStockCommandHandler
    : IRequestHandler<RemoveStockCommand>
{
    private readonly IInventoryRepository _inventoryRepository;

    public RemoveStockCommandHandler(
        IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task Handle(
        RemoveStockCommand request,
        CancellationToken cancellationToken)
    {
        var inventory = await _inventoryRepository.GetByProductIdAsync(
            request.ProductId,
            cancellationToken);

        if (inventory is null)
            throw new KeyNotFoundException("Inventory not found.");

        inventory.Decrease(request.Quantity);

        var movement = new InventoryMovement(
            inventory.Id,
            InventoryMovementType.Sale,
            request.Quantity,
            request.Notes);

        await _inventoryRepository.AddMovementAsync(
            movement,
            cancellationToken);

        await _inventoryRepository.SaveChangesAsync(cancellationToken);
    }
}
