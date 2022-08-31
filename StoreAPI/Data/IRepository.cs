using StoreAPI.Models.User;

namespace StoreAPI.Data
{
    public interface IRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        void Delete(int id);
        void Update(Customer person);
        void Create(Customer person);
    }
}
