Bootstrap.InitiailizeEnvironmentVariables(
    System.IO.Path.Combine(
        Directory.GetCurrentDirectory(), ".env"));

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ProductManagement")?
    .Replace("\"", string.Empty);

builder.Services
    .AddDbContextPool<ProductManagementContext>(options => options.UseSqlServer(connectionString));

builder.Services
    .AddGraphQLServer()
    .AddTypes()    
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddMutationConventions()
    .RegisterDbContext<ProductManagementContext>();

var app = builder.Build();
app.MapGraphQL();
app.RunWithGraphQLCommands(args);
