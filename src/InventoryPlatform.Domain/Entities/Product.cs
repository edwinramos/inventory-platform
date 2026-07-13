namespace InventoryPlatform.Domain.Entities;

public sealed class Product
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public string Sku { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public decimal Cost { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    public DateTime? UpdatedAtUtc { get; private set; }

    private Product()
    {
        // Required by EF Core
    }

    public Product(
        string name,
        string description,
        string sku,
        decimal price,
        decimal cost)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Sku = sku;
        Price = price;
        Cost = cost;
        CreatedAtUtc = DateTime.UtcNow;
    }

    public void Update(
        string name,
        string description,
        decimal price,
        decimal cost)
    {
        Name = name;
        Description = description;
        Price = price;
        Cost = cost;
        UpdatedAtUtc = DateTime.UtcNow;
    }
}

public sealed class ProductSummary
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;
    
    public string Description { get; private set; } = string.Empty;

    public string Sku { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public decimal Cost { get; private set; }
    private ProductSummary()
    {
        // Required by EF Core
    }

    public ProductSummary(
        Guid id,
        string name,
        string description,
        decimal cost,
        string sku,
        decimal price)
    {
        Id = id;
        Name = name;
        Description = description;
        Cost = cost;
        Sku = sku;
        Price = price;
    }
}
