using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensons;

var builder = WebApplication.CreateBuilder(args);

//Add service to the container.

//Infrastructure -EF Core
//Application - MediatR
//API - Carter, HealthChecks, ...

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

//Configure the HTTP request pipeline
app.useApiServices();
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
app.Run();
