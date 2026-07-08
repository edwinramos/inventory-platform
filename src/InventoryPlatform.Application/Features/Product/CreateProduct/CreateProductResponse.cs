namespace InventoryPlatform.Application.Features.Products.CreateProduct;

public sealed record CreateProductResponse(
    Guid Id,
    string Name,
    string Sku);
