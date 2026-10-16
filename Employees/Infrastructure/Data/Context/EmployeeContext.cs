using Microsoft.EntityFrameworkCore;
using WebApplication3.Features.Employees.Models;

namespace Employees.Infrastructure.Data.Context
{
    public class EmployeeContext(DbContextOptions<EmployeeContext> options) 
    : DbContext(options)
    {
        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}