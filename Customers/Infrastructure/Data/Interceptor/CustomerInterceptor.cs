using Customers.Features.Customers.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Claims;

namespace Customers.Infrastructure.Data.Interceptor
{
    public class CustomerInterceptor(IHttpContextAccessor httpContextAccessor)
        : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;
            if (context is null)
                return base.SavingChangesAsync(eventData, result, cancellationToken);

            SaveChanges(context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var context = eventData.Context;
            if (context is null)
                return base.SavingChanges(eventData, result);

            SaveChanges(context);

            return base.SavingChanges(eventData, result);
        }

        private void SaveChanges(DbContext context)
        {
            var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) is not null
                ? Guid.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!)
                : Guid.Empty;

            var entries = context.ChangeTracker.Entries<Customer>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Created = DateTimeOffset.UtcNow;
                    entry.Entity.Changed = DateTimeOffset.UtcNow;
                    entry.Entity.CreatedBy = userId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.Changed = DateTimeOffset.UtcNow;
                    entry.Entity.ChangedBy = userId;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.Deleted = DateTimeOffset.UtcNow;
                    entry.Entity.DeletedBy = userId;
                }
            }
        }
    }
}