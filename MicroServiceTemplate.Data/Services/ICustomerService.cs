using MicroServiceTemplate.Data.Contexts;
using MicroServiceTemplate.Data.Repositories;
using MicroServiceTemplate.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace MicroServiceTemplate.Data.Services
{
    public interface ICustomerService
    {
        Task<Customer> Create(Customer customer);
    }
}
