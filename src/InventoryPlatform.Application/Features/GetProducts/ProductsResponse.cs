using InventoryPlatform.Application.Features.Products.GetProduct;

namespace InventoryPlatform.Application.Features.Products.GetProducts;

public sealed record ProductsResponse(
    List<ProductResponse> Products);
