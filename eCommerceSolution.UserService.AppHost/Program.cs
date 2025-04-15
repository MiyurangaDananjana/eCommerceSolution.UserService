var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.eCommerce_API>("ecommerce-api");

builder.Build().Run();
