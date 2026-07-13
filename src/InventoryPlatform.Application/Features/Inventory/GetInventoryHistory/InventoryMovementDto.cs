namespace InventoryPlatform.Application.Features.Inventory.GetInventoryHistory;

public sealed record InventoryMovementDto(
    Guid Id,
    string Type,
    int Quantity,
    string? Notes,
    DateTime CreatedAtUtc);
