var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.LeetCodeAspire_ApiService>("apiservice");

builder.AddProject<Projects.LeetCodeAspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
