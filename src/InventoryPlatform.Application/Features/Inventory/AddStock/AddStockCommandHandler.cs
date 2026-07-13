using InventoryPlatform.Application.Common.Interfaces;
using InventoryPlatform.Domain.Entities;
using MediatR;

namespace InventoryPlatform.Application.Features.Inventory.AddStock;

public sealed class AddStockCommandHandler
    : IRequestHandler<AddStockCommand>
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IProductRepository _productRepository;

    public AddStockCommandHandler(
        IInventoryRepository inventoryRepository,
        IProductRepository productRepository)
    {
        _inventoryRepository = inventoryRepository;
        _productRepository = productRepository;
    }

    public async Task Handle(
        AddStockCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(
            request.ProductId,
            cancellationToken);

        if (product is null)
            throw new KeyNotFoundException("Product not found.");

        var inventory = await _inventoryRepository.GetByProductIdAsync(
            request.ProductId,
            cancellationToken);

        if (inventory is null)
        {
            inventory = new InventoryItem(request.ProductId);

            await _inventoryRepository.AddAsync(
                inventory,
                cancellationToken);
        }

        inventory.Increase(request.Quantity);

        var movement = new InventoryMovement(
            inventory.Id,
            InventoryMovementType.InitialStock,
            request.Quantity,
            request.Notes);

        await _inventoryRepository.AddMovementAsync(
            movement,
            cancellationToken);

        await _inventoryRepository.SaveChangesAsync(cancellationToken);
    }
}
