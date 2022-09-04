using System.Net.WebSockets;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Data.CustomersRepository;
using StoreAPI.Dtos.CustomerDtos;
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
        [HttpGet]
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
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var answer = _customerRepository.CustomerExists(id);

            if (answer)
            {
                var customer = await _customerRepository.GetCustomer(id);

                var customerDto = _mapper.Map<CustomerDto>(customer);

                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customerDto);
            }

            return NotFound("Customer does not exist!");

        }

        [HttpPost]
        public ActionResult<CustomerReadDto> CreateCustomer(CustomerReadDto customerReadDto)
        {
            var customer = _mapper.Map<Customer>(customerReadDto);

            _customerRepository.CreateCustomer(customer);

            var answer = _customerRepository.SaveChanges();

            if (answer == true)
            {
                return Ok($"Customer with id {customer.Id}");
            }
            return Problem("Oops! Customer was not created!");

        }

        [HttpDelete("{id}")]
        public ActionResult<CustomerDto> DeleteCustomer(int id)
        {
            var answer = _customerRepository.CustomerExists(id);

            if (answer)
            {
                _customerRepository.DeleteCustomer(id);

                var saved = _customerRepository.SaveChanges();

                if (saved == true)
                {
                    return Ok("Customer Deleted!");
                }
                return Problem("Oops! Customer was not deleted!");
            }

            return Problem("Oops! Customer was not created!");
        }


    }
}
