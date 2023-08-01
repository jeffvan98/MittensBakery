namespace MittensBakery.ProductManagement.App.Types;

[MutationType]
public static class Mutation
{
    public static async Task<Product> UpsertProduct(
        string name,
        DateTime? introductionDate,
        DateTime? salesDiscontinuationDate,
        DateTime? supportDiscontinuationDate,
        string? comment,
        ProductManagementContext context,
        CancellationToken cancellationToken)
    {
        var product = context.Products.Where(p => p.Name == name).FirstOrDefault();
        if (product is null)
        {
            product = new Product
            {
                Name = name,
                IntroductionDate = introductionDate,
                SalesDiscontinuationDate = salesDiscontinuationDate,
                SupportDiscontinuationDate = supportDiscontinuationDate,
                Comment = comment
            };
            context.Products.Add(product);
        }
        else
        {
            product.IntroductionDate = introductionDate;
            product.SalesDiscontinuationDate = salesDiscontinuationDate;
            product.SupportDiscontinuationDate = supportDiscontinuationDate;
            product.Comment = comment;
        }

        await context.SaveChangesAsync(cancellationToken);
        return product;
    }
}