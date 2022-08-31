using System.ComponentModel.DataAnnotations.Schema;

namespace StoreAPI.Models.Product
{
    [NotMapped]
    public class Rating
    {
        public float Rate { get; set; }

        public int Count { get; set; }
    }
}
