using MicroServiceTemplate.Data.Contexts;
using MicroServiceTemplate.Domain.Entities;

namespace MicroServiceTemplate.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        async Task<Customer> ICustomerRepository.Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChanges();
            return customer;
        }
    }
}
