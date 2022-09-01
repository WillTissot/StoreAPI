using System.ComponentModel.DataAnnotations.Schema;

namespace StoreAPI.Models.ProductT
{
    [NotMapped]
    public class Rating
    {
        public float Rate { get; set; }

        public int Count { get; set; }
    }
}
