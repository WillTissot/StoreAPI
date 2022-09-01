using System.Net.WebSockets;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Data;
using StoreAPI.Dtos;

namespace StoreAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository repository, IMapper mapper)
        {
            _customerRepository = repository;
            _mapper = mapper;
        }

        // GET: api/<CustomersController>
        [HttpGet(Name = "GetCustomers")]
        public ActionResult<IEnumerable<CustomerReadDto>> Get()
        {
            var customers = _customerRepository.GetAllCustomers();

            var customerDto = _mapper.Map<IEnumerable<CustomerReadDto>>(customers);

            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customerDto);

        }

        //[HttpGet(Name = "GetCustomer")]
        //public ActionResult<IEnumerable<CustomerReadDto>> GetCustomer(int id)
        //{
        //    var customer = _customerRepository.GetCustomer(id);

        //    var customerDto = _mapper.Map<CustomerReadDto>(customer);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(customerDto);

        //}


    }
}
