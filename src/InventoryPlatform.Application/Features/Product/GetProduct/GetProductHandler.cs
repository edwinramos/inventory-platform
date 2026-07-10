using InventoryPlatform.Application.Common.Exceptions;
using InventoryPlatform.Application.Common.Interfaces;
using MediatR;

namespace InventoryPlatform.Application.Features.Products.GetProduct;

public sealed class GetProductHandler
    : IRequestHandler<GetProductQuery, ProductResponse>
{
    private readonly IProductRepository _repository;

    public GetProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductResponse> Handle(
        GetProductQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (product is null)
        {
            throw new NotFoundException(
                $"Product '{request.Id}' was not found.");
        }

        return new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Sku,
            product.Price,
            product.Cost);
    }
}
