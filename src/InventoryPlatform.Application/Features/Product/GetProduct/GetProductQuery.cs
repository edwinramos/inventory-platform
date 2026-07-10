using MediatR;

namespace InventoryPlatform.Application.Features.Products.GetProduct;

public sealed record GetProductQuery(Guid Id)
    : IRequest<ProductResponse>;
