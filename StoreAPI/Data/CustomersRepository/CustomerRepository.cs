using Microsoft.EntityFrameworkCore;
using StoreAPI.Data.Context;
using StoreAPI.Models.User;

namespace StoreAPI.Data.CustomersRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void DeleteCustomer(int id)
        {
            var customer = GetCustomer(id);
            _context.Customers.Remove(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            customer.Address = _context.Addresses.FirstOrDefault(a => a.Id == customer.AddressId);
            customer.PhoneNumbers = _context.PhoneNumbers.Where(p => p.PersonId == customer.Id).ToList();

            return customer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            //var x = _context.Database.ExecuteSqlRaw("EXEC GetCustomers");

            return _context.Customers.Include(c => c.PhoneNumbers).Include(c => c.Address).ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }


    }
}
