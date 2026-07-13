using MediatR;

namespace InventoryPlatform.Application.Features.Inventory.AddStock;

public sealed record AddStockCommand(
    Guid ProductId,
    int Quantity,
    string? Notes) : IRequest;
