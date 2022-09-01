using Microsoft.EntityFrameworkCore;
using StoreAPI.Models.User;

namespace StoreAPI.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.Include(c => c.PhoneNumbers).Include(c => c.Address).ToList();
        }

        public IEnumerable<PhoneNumber> GetPhoneNumbers()
        {
            return _context.PhoneNumbers.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Customer person)
        {
            throw new NotImplementedException();
        }
    }
}
