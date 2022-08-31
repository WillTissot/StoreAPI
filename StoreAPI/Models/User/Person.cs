using System.ComponentModel.DataAnnotations.Schema;
using StoreAPI.Models.Enums;

namespace StoreAPI.Models.User
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

    }
}
