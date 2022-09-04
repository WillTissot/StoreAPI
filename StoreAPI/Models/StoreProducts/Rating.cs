using System.ComponentModel.DataAnnotations.Schema;

namespace StoreAPI.Models.StoreProducts
{
    public class Rating
    {
        [ForeignKey("Product")]
        public int Id { get; set; }
        public decimal Rate { get; set; }
        public int Count { get; set; }

        public Product Product { get; set; }
    }
}
