using AutoMapper;
using Newtonsoft.Json;
using RestSharp;
using StoreAPI.Dtos.CustomerDtos;
using StoreAPI.Dtos.ProductDtos;
using StoreAPI.Models.StoreProducts;
using StoreAPI.Models.User;

namespace StoreAPI.Data.Context
{
    public class DataSeeder
    {
        private readonly string _path = @".\Files\JSON Files\sample_user.json";

        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        public DataSeeder(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async void Seed()
        {
            if (!_db.Customers.Any())
            {
                using (StreamReader r = new StreamReader(Path.GetFullPath(_path)))
                {
                    string json = r.ReadToEnd();

                    var users = JsonConvert.DeserializeObject<UsersSerializeDto>(json);

                    var customers = _mapper.Map<List<Customer>>(users.Users);

                    _db.Customers.AddRange(customers);

                    _db.SaveChanges();
                }
            }
        }

        public async Task SeedProducts()
        {
            if (!_db.Products.Any())
            {
                try
                {
                    var url = "https://fakestoreapi.com/products/";
                    var restClient = new RestClient(url);
                    var request = new RestRequest(url, RestSharp.Method.Get);
                    RestResponse response = await restClient.ExecuteAsync(request);
                    var output = response.Content;
                    if (output != null)
                    {
                        var productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(output);
                        var products = _mapper.Map<List<Product>>(productDtos);

                        if (products != null)
                        {
                            _db.Products.AddRangeAsync(products);
                            await _db.SaveChangesAsync();
                        }

                    }
                }
                catch (Exception)
                {

                }
            }
        }

        
    }
}
