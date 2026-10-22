using Employees.Features.Employees.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.Infrastructure.Data.Context
{
  public class EmployeesContext(DbContextOptions<EmployeesContext> options)
  : DbContext(options)
  {
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeesContext).Assembly);
      base.OnModelCreating(modelBuilder);
    }
  }
}