using System.ComponentModel.DataAnnotations.Schema;
using StoreAPI.Models.Enums;

namespace StoreAPI.Models.User
{
    public class PhoneNumber
    {
        public int Id { get; set; }

        public string PhoneNum { get; set; }

        public string PhoneNumberType { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public virtual Customer Person { get; set; }
    }
}
