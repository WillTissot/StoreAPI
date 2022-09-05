using Microsoft.EntityFrameworkCore;
using RestSharp;
using StoreAPI.Data.Context;
using StoreAPI.Dtos.ProductDtos;
using StoreAPI.Models.Cart;
using StoreAPI.Models.StoreProducts;
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
                        .Include(x => x.Address)
                        .Include(x => x.PhoneNumbers)
                        .Select(s => s)
                        .ToList();
        }

        public  IEnumerable<Product> GetCustomerProducts(int customerId)
        {
            return _context.Orders.Where(o => o.CustomerId == customerId).Include(p => p.Product.Rating).Select(o => o.Product).ToList();
        }
                    

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
