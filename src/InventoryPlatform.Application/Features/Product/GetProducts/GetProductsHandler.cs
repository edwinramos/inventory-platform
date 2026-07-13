using InventoryPlatform.Application.Common.Exceptions;
using InventoryPlatform.Application.Common.Interfaces;
using InventoryPlatform.Application.Common.Models;
using InventoryPlatform.Application.Features.Products.GetProduct;
using InventoryPlatform.Domain.Entities;
using MediatR;

namespace InventoryPlatform.Application.Features.Products.GetProducts;

public sealed class GetProductsHandler
    : IRequestHandler<GetProductsQuery, PagedResponse<ProductsResponse>>
{
    private readonly IProductRepository _repository;

    public GetProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResponse<ProductsResponse>> Handle(
        GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetProductsAsync(
            request.Page,
            request.PageSize,
            cancellationToken);

        if (products is null)
        {
            throw new NotFoundException(
                $"Products was not found.");
        }

        var productsList = products.Select(product=> new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Sku,
            product.Price,
            product.Cost));
        
        var itemCount = productsList.Count();
        
        return new PagedResponse<ProductsResponse>(productsList as IReadOnlyList<ProductsResponse>, request.Page, request.PageSize, itemCount);
    }
}
