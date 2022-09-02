using StoreAPI.Models.Cart;
using StoreAPI.Models.User;

namespace StoreAPI.Data.CartRepository
{
    public interface ICartRepository
    {
        void CreateOrder(IEnumerable<Order> Order);
        IEnumerable<Customer> GetProductCustomers(int productId);
        IEnumerable<int> GetUserProductIds(int customerId);
        bool SaveChanges();

    }    
}
