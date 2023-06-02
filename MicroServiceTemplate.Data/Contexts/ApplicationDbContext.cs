using Microsoft.EntityFrameworkCore;
using MicroServiceTemplate.Domain.Entities;

namespace MicroServiceTemplate.Data.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuring Customers
            modelBuilder.Entity<Customer>()
                .ToContainer("Customers") // ToContainer
                .HasPartitionKey(c => c.Id); // Partition Key
        }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
