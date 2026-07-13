using InventoryPlatform.Application.Common.Exceptions;
using InventoryPlatform.Application.Common.Interfaces;
using MediatR;

namespace InventoryPlatform.Application.Features.Inventory.GetCurrentStock;

public sealed class GetCurrentStockHandler
    : IRequestHandler<GetCurrentStockQuery, GetCurrentStockResponse>
{
    private readonly IInventoryRepository _repository;

    public GetCurrentStockHandler(IInventoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetCurrentStockResponse> Handle(
        GetCurrentStockQuery request,
        CancellationToken cancellationToken)
    {
        var inventoryItem = await _repository.GetByProductIdAsync(
            request.ProductId,
            cancellationToken);

        if (inventoryItem is null)
        {
            throw new NotFoundException(
                $"Product '{request.ProductId}' was not found.");
        }

        return new GetCurrentStockResponse(
            inventoryItem.Id,
            inventoryItem.QuantityOnHand);
    }
}
