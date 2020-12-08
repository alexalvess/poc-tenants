using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poc.Tenants.Interfaces;
using Poc.Tenants.Models;

namespace Poc.Tenants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            var id = await _customerRepository.InsertCustomerAsync(customer);

            return Created("/api/customer/", id);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();

            return Ok(customers);
        }
    }
}