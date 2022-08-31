using StoreAPI.Models.User;

namespace StoreAPI.Data
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
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

        public void Update(Customer person)
        {
            throw new NotImplementedException();
        }
    }
}
