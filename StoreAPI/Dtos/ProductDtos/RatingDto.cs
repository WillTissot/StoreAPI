using Newtonsoft.Json;

namespace StoreAPI.Dtos.ProductDtos
{
    public class RatingDto
    {
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
