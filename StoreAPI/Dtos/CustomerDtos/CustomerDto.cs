using Newtonsoft.Json;

namespace StoreAPI.Dtos.CustomerDtos
{
    public class CustomerDto
    {
        [JsonProperty("userId")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }


        [JsonProperty("address")]
        public AddressDto Address { get; set; }

        [JsonProperty("phoneNumbers")]
        public IEnumerable<PhoneNumberDto> PhoneNumbers { get; set; }
    }
}
