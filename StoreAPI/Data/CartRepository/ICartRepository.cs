using StoreAPI.Models.Cart;
using StoreAPI.Models.StoreProducts;
using StoreAPI.Models.User;

namespace StoreAPI.Data.CartRepository
{
    public interface ICartRepository
    {
        void CreateOrder(IEnumerable<Order> Order);
        IEnumerable<Customer> GetProductCustomers(int productId);
        IEnumerable<Product> GetCustomerProducts(int customerId);
        bool SaveChanges();

    }    
}
