using MicroServiceTemplate.Domain.Entities;

namespace MicroServiceTemplate.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> Create(Customer customer);
    }
}
