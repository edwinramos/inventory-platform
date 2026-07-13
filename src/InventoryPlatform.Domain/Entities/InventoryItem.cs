namespace InventoryPlatform.Domain.Entities;

public sealed class InventoryItem
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }

    public Product Product { get; private set; } = default!;

    public int QuantityOnHand { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    public DateTime UpdatedAtUtc { get; private set; }

    private InventoryItem() { }

    public InventoryItem(Guid productId)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        QuantityOnHand = 0;
        CreatedAtUtc = DateTime.UtcNow;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void Increase(int quantity)
    {
        QuantityOnHand += quantity;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void Decrease(int quantity)
    {
        if (QuantityOnHand < quantity)
            throw new InvalidOperationException("Insufficient stock.");

        QuantityOnHand -= quantity;
        UpdatedAtUtc = DateTime.UtcNow;
    }
}
