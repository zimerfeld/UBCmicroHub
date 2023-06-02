using Microsoft.EntityFrameworkCore;
using MicroServiceTemplate.Domain.Entities;

namespace MicroServiceTemplate.Data.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChanges();
    }
}
