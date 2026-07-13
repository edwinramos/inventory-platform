using MediatR;

namespace InventoryPlatform.Application.Features.Inventory.RemoveStock;

public sealed record RemoveStockCommand(
    Guid ProductId,
    int Quantity,
    string? Notes) : IRequest;
