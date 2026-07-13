using MediatR;

namespace InventoryPlatform.Application.Features.Inventory.GetCurrentStock;
public sealed record GetCurrentStockQuery(Guid ProductId)
    : IRequest<GetCurrentStockResponse>;
