using System;
using System.Threading.Tasks;
using RecruitR.Domain.Customer;

namespace RecruitR.Persistence.Repositories.Customers
{
    public interface ICustomersRepository
    {
        Task Add(Customer customer);
        Task<Customer> Get(Guid id);
        void Delete(Customer customer);
        void Update(Customer customer);
        Task SaveChanges();
    }
}