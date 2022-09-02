using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using StoreAPI.Data.CartRepository;
using StoreAPI.Data.CustomersRepository;
using StoreAPI.Dtos.CustomerDtos;
using StoreAPI.Dtos.OrderDtos;
using StoreAPI.Dtos.ProductDtos;
using StoreAPI.Models.Cart;

namespace StoreAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public OrdersController(ICartRepository repository, IMapper mapper)
        {
            _cartRepository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<IEnumerable<OrderDto>> CreateOrder(IEnumerable<OrderDto> orderDto)
        {
            var order = _mapper.Map<IEnumerable<Order>>(orderDto);

            _cartRepository.CreateOrder(order);

            var answer = _cartRepository.SaveChanges();

            if (answer == true)
            {
                return Ok("Order Created!");
            }
            return Problem("Oops! Order was not created!");


        }

        //get product's all buyers
        [HttpGet("/Product/{id}")]
        public ActionResult<IEnumerable<CustomerDto>> GetProductCustomers(int id)
        {
            var customer = _cartRepository.GetProductCustomers(id);

            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customer);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customersDto);

        }
        //get all products purchased from a customer
        [HttpGet("/Customer/{id}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetCustomerProdcuts(int id)
        {
            var listOfProductDtos = new List<ProductDto>();
            var productIds = _cartRepository.GetUserProductIds(id);



            foreach (var productId in productIds)
            {
                try
                {
                    var url = "https://fakestoreapi.com/products/" + productId.ToString(); 
                    var restClient = new RestClient(url);
                    var request = new RestRequest(url, RestSharp.Method.Get);
                    RestResponse response = await restClient.ExecuteAsync(request);
                    var output = response.Content;
                    if (output != null)
                    {
                        var productDto = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductDto>(output);
                        if (productDto != null)
                        {
                            listOfProductDtos.Add(productDto);
                        }

                    }
                }
                catch (Exception)
                {

                }
            }

            if (listOfProductDtos == null)
            {
                return NotFound("Oops! No prodcuts found.");
            }
            return Ok(listOfProductDtos);

        }
    }
}
