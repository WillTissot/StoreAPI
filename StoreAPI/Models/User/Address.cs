using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreAPI.Models.User
{
    public class Address
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string StreetAddress { get; set; }

    }
}
