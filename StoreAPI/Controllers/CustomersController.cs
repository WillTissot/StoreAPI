using System.Net.WebSockets;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Data;
using StoreAPI.Dtos;
using StoreAPI.Models.User;

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

        // GET: api/v1/
        [HttpGet(Name = "GetCustomers")]
        public ActionResult<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();

            var customerDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customerDto);

        }
        // GET: api/v1/{id}
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            var customer = _customerRepository.GetCustomer(id);

            var customerDto = _mapper.Map<CustomerDto>(customer);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customerDto);

        }

        [HttpPost]
        public ActionResult<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            _customerRepository.CreateCustomer(customer);

            var answer = _customerRepository.SaveChanges();

            if (answer == true)
            {
                return Ok("Customer Created!");
            }
            return Problem("Oops! Customer was not created!");

        }


        [HttpPut("{id}")]
        public ActionResult<CustomerDto> UpdateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            _customerRepository.UpdateCustomer(customer);

            var answer = _customerRepository.SaveChanges();

            if (answer == true)
            {
                return Ok("Customer Updated!");
            }
            return Problem("Oops! Customer was not updated!");

        }


        [HttpDelete("{id}")]
        public ActionResult<CustomerDto> DeleteCustomer(int id)
        {

            _customerRepository.DeleteCustomer(id);

            var answer = _customerRepository.SaveChanges();

            if (answer == true)
            {
                return Ok("Customer Deleted!");
            }
            return Problem("Oops! Customer was not deleted!");

        }


    }
}
