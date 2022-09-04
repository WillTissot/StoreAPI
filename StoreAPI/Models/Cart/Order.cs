using System.ComponentModel.DataAnnotations;
using StoreAPI.Models.StoreProducts;
using StoreAPI.Models.User;

namespace StoreAPI.Models.Cart
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }       
}
