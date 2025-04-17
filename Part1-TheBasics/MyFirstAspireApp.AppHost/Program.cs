var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MyFirstAspireApp_ApiService>("apiservice");

builder.AddProject<Projects.MyFirstAspireApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
