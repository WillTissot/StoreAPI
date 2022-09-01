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

        public void Create(Customer person)
        {
            _context.Add(person);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            return _context.Customers.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
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
