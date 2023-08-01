namespace MittensBakery.SalesManagement.App.Types;

[MutationType]
public static class Mutation
{
    public static async Task<Product> UpsertProductAsync(
        string description,
        SalesManagementContext context,
        CancellationToken cancellationToken)
    {
        Product? product = await context.Products
            .Where(p => p.Description == description)
            .FirstOrDefaultAsync(cancellationToken);

        if (product is null)
        {
            product = new Product { Description = description };
            context.Products.Add(product);
            await context.SaveChangesAsync(cancellationToken);
        }

        return product;
    }
}