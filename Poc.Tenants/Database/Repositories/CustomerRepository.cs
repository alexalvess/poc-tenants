using MongoDB.Driver;
using Poc.Tenants.Interfaces;
using Poc.Tenants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.Tenants.Database.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _mongoCollection;

        public CustomerRepository(IMongoClient mongoClient, string database, string collection)
        {
            _mongoCollection = mongoClient.GetDatabase(database).GetCollection<Customer>(collection);
        }

        public async Task<string> InsertCustomerAsync(Customer customer)
        {
            await _mongoCollection.InsertOneAsync(customer);

            return customer.Id;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _mongoCollection.AsQueryable().ToListAsync();
        }
    }
}
