using System.ComponentModel.DataAnnotations.Schema;
using StoreAPI.Models.Enums;

namespace StoreAPI.Models.User
{
    public class PhoneNumber
    {
        public int Id { get; set; }

        public string PhoneNum { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
    }
}
