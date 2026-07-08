using InventoryPlatform.Application.Common.Exceptions;
using InventoryPlatform.Application.Common.Interfaces;
using InventoryPlatform.Domain.Entities;
using MediatR;

namespace InventoryPlatform.Application.Features.Products.CreateProduct;

public sealed class CreateProductHandler
    : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateProductResponse> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        if (await _repository.ExistsBySkuAsync(request.Sku, cancellationToken))
        {
            throw new ConflictException(
                $"A product with SKU '{request.Sku}' already exists.");
        }

        var product = new Product(
            request.Name,
            request.Description,
            request.Sku,
            request.Price,
            request.Cost);

        await _repository.AddAsync(product, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return new CreateProductResponse(
            product.Id,
            product.Name,
            product.Sku);
    }
}
