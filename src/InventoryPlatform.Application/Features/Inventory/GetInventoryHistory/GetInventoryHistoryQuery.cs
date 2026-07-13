using MediatR;

namespace InventoryPlatform.Application.Features.Inventory.GetInventoryHistory;

public sealed record GetInventoryHistoryQuery(Guid ProductId)
    : IRequest<List<InventoryMovementDto>>;
