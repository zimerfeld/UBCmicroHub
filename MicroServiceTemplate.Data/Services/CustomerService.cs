using MicroServiceTemplate.Data.Contexts;
using MicroServiceTemplate.Data.Repositories;
using MicroServiceTemplate.Domain.Entities;

namespace MicroServiceTemplate.Data.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<Customer> Create(Customer customer)
        {
            var response = await _customerRepository.Create(customer);
            return response;
        }
    }
}
