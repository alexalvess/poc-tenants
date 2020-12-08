using Poc.Tenants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.Tenants.Interfaces
{
    public interface ICustomerRepository
    {
        Task<string> InsertCustomerAsync(Customer customer);

        Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}
