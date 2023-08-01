namespace MittensBakery.SalesManagement.App.Types;

[QueryType]
public static class Query
{
    public static async Task<IReadOnlyList<SalesOrder>> GetSalesOrdersAsync(
        SalesManagementContext context,
        CancellationToken cancellationToken) =>
        await context.SalesOrders.OrderBy(s => s.SalesOrderId).ToListAsync(cancellationToken);

    public static async Task<SalesOrder?> GetSalesOrderByIdAsync(
        int id, 
        SalesManagementContext context,
        CancellationToken cancellationToken) =>
        await context.SalesOrders.FindAsync(id, cancellationToken);

    public static async Task<IReadOnlyList<Product>> GetProductsAsync(
        SalesManagementContext context,
        CancellationToken cancellationToken) =>
        await context.Products.OrderBy(p => p.ProductId).ToListAsync(cancellationToken);

    public static async Task<Product?> GetProductByIdAsync(
        int id, 
        SalesManagementContext context,
        CancellationToken cancellationToken) =>
        await context.Products.FindAsync(id, cancellationToken);

    public static async Task<IReadOnlyList<Customer>> GetCustomersAsync(
        SalesManagementContext context,
        CancellationToken cancellationToken) =>  
        await context.Customers.OrderBy(c => c.CustomerId).ToListAsync();

    public static async Task<Customer?> GetCustomerByIdAsync(
        int id, 
        SalesManagementContext context,
        CancellationToken cancellationToken) =>
        await context.Customers.FindAsync(id, cancellationToken);
}
