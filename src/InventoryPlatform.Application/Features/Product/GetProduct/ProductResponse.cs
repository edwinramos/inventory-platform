namespace InventoryPlatform.Application.Features.Products.GetProduct;

public sealed record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    string Sku,
    decimal Price,
    decimal Cost);
