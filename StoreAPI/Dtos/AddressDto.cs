using Newtonsoft.Json;

namespace StoreAPI.Dtos
{
    public class AddressDto
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }
    }
}
