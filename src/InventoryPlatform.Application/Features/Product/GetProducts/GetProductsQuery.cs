using InventoryPlatform.Application.Common.Models;
using MediatR;

namespace InventoryPlatform.Application.Features.Products.GetProducts;

public sealed record GetProductsQuery(int page, int pageSize) : PagedRequest, IRequest<PagedResponse<ProductsResponse>>;
