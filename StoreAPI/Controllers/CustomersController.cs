using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Data;
using StoreAPI.Dtos;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public ActionResult<IEnumerable<CustomerReadDto>> Get()
        {
            var customers = _repository.GetAll();

            var customerDto = _mapper.Map<IEnumerable<CustomerReadDto>>(customers);

            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customerDto);

        }


    }
}
