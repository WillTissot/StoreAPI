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
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public OrdersController(ICartRepository cartRepository, IMapper mapper, ICustomerRepository customerRepository)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        //creating order for one customer
        [HttpPost]
        public ActionResult<IEnumerable<OrderDto>> CreateOrder(List<OrderDto> orderDto)
        {
            if (orderDto.Count == 0)
                return NotFound("empty cart");

            var answer = _customerRepository.CustomerExists(orderDto[0].CustomerId);

            if (answer)
            {
                var order = _mapper.Map<IEnumerable<Order>>(orderDto);

                _cartRepository.CreateOrder(order);

                var saved = _cartRepository.SaveChanges();

                if (saved == true)
                {
                    return Ok("Order Created!");
                }
                return Problem("Oops! Order was not created!");
            }

            return NotFound("customer does not exist!");

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
        public ActionResult<IEnumerable<ProductDto>> GetCustomerProdcuts(int id)
        {
            var answer = _customerRepository.CustomerExists(id);

            if (answer)
            {
                var listOfProducts = _cartRepository.GetCustomerProducts(id);
                var listOfProductDtos = _mapper.Map<IEnumerable<ProductDto>>(listOfProducts);

                if (listOfProductDtos == null)
                {
                    return NotFound("Oops! No prodcuts found.");
                }
                return Ok(listOfProductDtos);
            }
            return NotFound("customer does not exist!");
        }
    }
}
