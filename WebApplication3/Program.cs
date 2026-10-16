using FastEndpoints;
using Scalar.AspNetCore;
using WebApplication3.Features.Employees.CreateEmployee;

var bld = WebApplication.CreateBuilder();
bld.Services.AddOpenApi();
bld.Services.AddFastEndpoints();

var app = bld.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseFastEndpoints();
app.Run();