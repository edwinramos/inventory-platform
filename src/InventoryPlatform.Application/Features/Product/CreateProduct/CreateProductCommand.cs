using MediatR;

namespace InventoryPlatform.Application.Features.Products.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    string Sku,
    decimal Price,
    decimal Cost)
    : IRequest<CreateProductResponse>;
