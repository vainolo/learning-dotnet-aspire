var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.SimpleApp_Web1>("Web1").WithExternalHttpEndpoints();

builder.Build().Run();
