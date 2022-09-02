using Microsoft.EntityFrameworkCore;
using RestSharp;
using StoreAPI.Data.Context;
using StoreAPI.Dtos.ProductDtos;
using StoreAPI.Models.Cart;
using StoreAPI.Models.User;

namespace StoreAPI.Data.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly string _productUrl = "https://fakestoreapi.com/products";
        public void CreateOrder(IEnumerable<Order> Order)
        {
            _context.Orders.AddRange(Order);
        }

        public IEnumerable<Customer> GetProductCustomers(int productId)
        {
            return _context.Orders
                        .Where(o => o.ProductId == productId)
                        .Join(_context.Customers,
                        o => o.CustomerId,
                        c => c.Id,
                        (o, c) => c)
                        .Select(s => s)
                        .ToList();
        }

        public  IEnumerable<int> GetUserProductIds(int customerId)
        {
            return _context.Orders.Where(o => o.CustomerId == customerId).Select(o => o.ProductId).ToList();
        }
                    

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
