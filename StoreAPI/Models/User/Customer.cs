using System.ComponentModel.DataAnnotations.Schema;
using StoreAPI.Models.Enums;

namespace StoreAPI.Models.User
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public Address Address { get; set; }
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }



    }
}
