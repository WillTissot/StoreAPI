using StoreAPI.Models.User;

namespace StoreAPI.Data.CustomersRepository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Task<Customer> GetCustomer(int id);
        void DeleteCustomer(int id);
        void CreateCustomer(Customer person);
        bool CustomerExists(int id);
        bool SaveChanges();


    }
}
