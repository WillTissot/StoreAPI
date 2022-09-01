using StoreAPI.Models.User;

namespace StoreAPI.Data
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<PhoneNumber> GetPhoneNumbers();
        Customer GetCustomer(int id);
        void Delete(int id);
        void Update(Customer person);
        void Create(Customer person);
        bool SaveChanges();
    }
}
