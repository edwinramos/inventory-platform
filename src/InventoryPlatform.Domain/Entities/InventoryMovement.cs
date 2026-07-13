namespace InventoryPlatform.Domain.Entities;

public sealed class InventoryMovement
{
    public Guid Id { get; private set; }

    public Guid InventoryItemId { get; private set; }

    public InventoryItem InventoryItem { get; private set; } = default!;

    public InventoryMovementType Type { get; private set; }

    public int Quantity { get; private set; }

    public string? Notes { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    private InventoryMovement() { }

    public InventoryMovement(
        Guid inventoryItemId,
        InventoryMovementType type,
        int quantity,
        string? notes = null)
    {
        Id = Guid.NewGuid();
        InventoryItemId = inventoryItemId;
        Type = type;
        Quantity = quantity;
        Notes = notes;
        CreatedAtUtc = DateTime.UtcNow;
    }
}

public enum InventoryMovementType
{
    InitialStock = 1,
    Purchase = 2,
    Sale = 3,
    Adjustment = 4,
    Damaged = 5,
    Return = 6
}
