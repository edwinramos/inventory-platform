using MediatR;

namespace InventoryPlatform.Application.Features.Products.GetProduct;

public sealed record GetProductsRequest(
    int Page = 1,
    int PageSize = 10);
