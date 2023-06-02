using Microsoft.AspNetCore.Mvc;
using MicroServiceTemplate.Domain.Entities;
using MicroServiceTemplate.Data.Contexts;
using MicroServiceTemplate.Data.Repositories;
using System.Net;
using MicroServiceTemplate.Data.Services;

namespace MicroServiceTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            var response = await _customerService.Create(customer);
            return Ok(customer.Id);
        }
        
    }
}