using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecruitR.Domain.Customer;

namespace RecruitR.Persistence.Repositories.Customers
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly RecruitDbContext _context;

        public CustomersRepository(RecruitDbContext context)
        {
            _context = context;
        }

        public async Task Add(Customer customer)
            => await _context.Customers.AddAsync(customer);

        public async Task<Customer> Get(Guid id)
            =>  await _context.Customers.SingleOrDefaultAsync(x => x.Id == new CustomerId(id));

        public void Delete(Customer customer)
            =>  _context.Customers.Remove(customer);

        public void Update(Customer customer)
            => _context.Customers.Update(customer);

        public async Task SaveChanges()
            => await _context.SaveChangesAsync();
    }
}