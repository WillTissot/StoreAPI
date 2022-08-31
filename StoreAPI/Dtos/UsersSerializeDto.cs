using Newtonsoft.Json;

namespace StoreAPI.Dtos
{
    public class UsersSerializeDto
    {
        [JsonProperty("users")]
        public List<CustomerReadDto> Users;
    }
}
