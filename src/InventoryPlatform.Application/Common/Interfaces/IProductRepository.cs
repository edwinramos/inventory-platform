using InventoryPlatform.Domain.Entities;

namespace InventoryPlatform.Application.Common.Interfaces;

public interface IProductRepository
{
    Task<bool> ExistsBySkuAsync(
        string sku,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Product product,
        CancellationToken cancellationToken = default);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
    
    Task<Product?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
        
    Task<List<ProductSummary>> GetProductsAsync(
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);
}
