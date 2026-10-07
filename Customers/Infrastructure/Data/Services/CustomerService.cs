using Customers.Features.Customers.CreateCustomer;
using Customers.Features.Customers.DeleteCustomer;
using Customers.Features.Customers.GetCustomer;
using Customers.Features.Customers.Model;
using Customers.Features.Customers.UpdateCustomer;
using Customers.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Customers.Infrastructure.Data.Services
{
    public interface ICustomerService : ICreateCustomerService, IUpdateCustomerService, IDeleteCustomerService, IGetCustomerService
    { }

    public class CustomerService(CustomerContext context)
        : ICustomerService
    {
        public async Task<Customer> Create(Customer customer, CancellationToken cancellationToken = default)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync(cancellationToken);
            return customer;
        }

        public async Task<Customer?> Delete(Guid customerId, CancellationToken cancellationToken = default)
        {
            var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer is null) return null;

            context.Remove(customer);
            await context.SaveChangesAsync(cancellationToken);
            return customer;
        }

        public Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(context.Customers.AsNoTracking().AsEnumerable());
        }

        public Task<Customer?> Get(Guid customerId, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(context.Customers.AsNoTracking().FirstOrDefault(c => c.Id == customerId));
        }

        public async Task<Customer> Update(Customer customer, CancellationToken cancellationToken = default)
        {
            context.Update(customer);
            await context.SaveChangesAsync(cancellationToken);
            return customer;
        }
    }
}