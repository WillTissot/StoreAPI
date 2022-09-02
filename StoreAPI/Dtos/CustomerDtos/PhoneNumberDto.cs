using Newtonsoft.Json;
using StoreAPI.Models.Enums;

namespace StoreAPI.Dtos.CustomerDtos
{
    public class PhoneNumberDto
    {
        [JsonProperty("number")]
        public string PhoneNum { get; set; }

        [JsonProperty("type")]
        public string PhoneNumberType { get; set; }
    }
}
