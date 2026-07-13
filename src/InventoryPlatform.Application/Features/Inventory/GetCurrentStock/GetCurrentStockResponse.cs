namespace InventoryPlatform.Application.Features.Inventory.GetCurrentStock;
public sealed record GetCurrentStockResponse(
    Guid ProductId,
    int QuantityOnHand);
