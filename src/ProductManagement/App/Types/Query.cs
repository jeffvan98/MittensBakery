namespace MittensBakery.ProductManagement.App.Types;

[QueryType]
public static class Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static async Task<IReadOnlyCollection<Product>> GetProducts(
        ProductManagementContext context,
        CancellationToken cancellationToken)
        => await context.Products.OrderBy(p => p.ProductId).ToListAsync(cancellationToken);

    public static async Task<Product?> GetProductById(
        int productId,
        ProductManagementContext context,
        CancellationToken cancellationToken)
        => await context.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync(cancellationToken);
}
