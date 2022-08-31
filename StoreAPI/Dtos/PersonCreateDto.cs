using StoreAPI.Models.User;
using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Dtos
{
    public class PersonCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public AddressDto Address { get; set; }
        [Required]
        public IEnumerable<PhoneNumberDto> PhoneNumbers { get; set; }
    }
}
