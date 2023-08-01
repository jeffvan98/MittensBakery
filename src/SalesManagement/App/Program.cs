Bootstrap.InitiailizeEnvironmentVariables(
    System.IO.Path.Combine(
        Directory.GetCurrentDirectory(), ".env"));
        
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SalesManagement")?
    .Replace("\"", string.Empty);

builder.Services.AddDbContextPool<SalesManagementContext>(options => options.UseSqlServer(connectionString));

builder.Services
    .AddGraphQLServer()
    .AddTypes()
    .AddMutationConventions()
    .RegisterDbContext<SalesManagementContext>();

var app = builder.Build();
app.MapGraphQL();
app.RunWithGraphQLCommands(args);
