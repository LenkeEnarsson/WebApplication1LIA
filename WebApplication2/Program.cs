using Customers.Features.Customers.Extensions;
using Customers.Infrastructure.Data.Extensions;
using Customers.Infrastructure.Messaging;
using Employees.Features.Employees.Extensions;
using Employees.Infrastructure.Data.Extensions;
using Employees.Infrastructure.Messaging;
using FastEndpoints;
using Scalar.AspNetCore;
using Workloads.Infrastructure.Data.Extensions;
using Workloads.Infrastructure.Messaging;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets(typeof(Program).Assembly);

builder.Services.AddFastEndpoints();

//Add services to the container
builder.Services.AddOpenApi();

builder.Services //Registrera lyssnarna i workloadmodulen
  .AddCustomersMessaging()
  .AddEmployeeMessaging()
  .AddWorkloadsMessaging();

builder.Services
  .AddCustomersHandlers() //Registrerar mappers
  .AddEmployeeHandlers();

builder.Services
  .AddCustomersData(builder.Configuration)
  .AddEmployeesData(builder.Configuration) //Lägger även till DbContext
  .AddWorkloadsData(builder.Configuration); //Registrerar eventservice med workloadservice

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  _ = app.MapOpenApi();
  _ = app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app //Skapar dbContext och se till att det finns migration
  .UseCustomersData()
  .UseEmployeesData();

app.UseFastEndpoints();

app.Run();