using InventoryPlatform.Application.Common.Interfaces;
using InventoryPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryPlatform.Infrastructure.Persistence.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly InventoryDbContext _context;

    public ProductRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsBySkuAsync(
        string sku,
        CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .AnyAsync(p => p.Sku == sku, cancellationToken);
    }

    public async Task AddAsync(
        Product product,
        CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<Product?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<List<ProductSummary>> GetProductsAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .OrderBy(p => p.Id) 
                .Skip((page - 1) * pageSize)
                .Take(pageSize).Select(product=> new ProductSummary(
                product.Id, 
                product.Name,
                product.Description,
                product.Cost,
                product.Sku,
                product.Price)).ToListAsync();
    }
}
