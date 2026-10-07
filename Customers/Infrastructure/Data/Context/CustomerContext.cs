using Customers.Features.Customers.Model;
using Microsoft.EntityFrameworkCore;

namespace Customers.Infrastructure.Data.Context
{
    public class CustomerContext(DbContextOptions<CustomerContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers => Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}