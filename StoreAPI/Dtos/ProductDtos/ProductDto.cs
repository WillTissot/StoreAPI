using Newtonsoft.Json;

namespace StoreAPI.Dtos.ProductDtos
{
    public class ProductDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("rating")]
        public RatingDto Rating { get; set; }
    }
}
