var builder = DistributedApplication.CreateBuilder(args);

var web = builder.AddProject("web", "../ManufacturingOffice.Web/ManufacturingOffice.Web.csproj");

builder.Build().Run();
