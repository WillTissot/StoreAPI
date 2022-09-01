using StoreAPI.Models.User;

namespace StoreAPI.Data
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        void DeleteCustomer(int id);
        void UpdateCustomer(Customer person);
        void CreateCustomer(Customer person);
        bool SaveChanges();
    }
}
