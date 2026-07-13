using InventoryPlatform.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryPlatform.Application.Features.Inventory.GetInventoryHistory;

public sealed class GetInventoryHistoryHandler
    : IRequestHandler<GetInventoryHistoryQuery, List<InventoryMovementDto>>
{
    private readonly IApplicationDbContext _context;

    public GetInventoryHistoryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<InventoryMovementDto>> Handle(
        GetInventoryHistoryQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.InventoryMovements
            .AsNoTracking()
            .Where(x => x.InventoryItem.ProductId == request.ProductId)
            .OrderByDescending(x => x.CreatedAtUtc)
            .Select(x => new InventoryMovementDto(
                x.Id,
                x.Type.ToString(),
                x.Quantity,
                x.Notes,
                x.CreatedAtUtc))
            .ToListAsync(cancellationToken);
    }
}
