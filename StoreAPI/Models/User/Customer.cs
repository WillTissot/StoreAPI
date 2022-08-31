using System.ComponentModel.DataAnnotations.Schema;

namespace StoreAPI.Models.User
{
    [NotMapped]
    public class Customer : Person
    {
        public int CustomerNumber { get; set; }
    }
}
