using Newtonsoft.Json;

namespace StoreAPI.Dtos.CustomerDtos
{
    public class UsersSerializeDto
    {
        [JsonProperty("users")]
        public List<CustomerDto> Users;
    }
}
