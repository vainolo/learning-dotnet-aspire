var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.SimpleApp_Web1>("web1").WithExternalHttpEndpoints();

builder.Build().Run();
