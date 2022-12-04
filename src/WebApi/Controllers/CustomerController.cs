using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("{id:long}")]   
        public async Task<ActionResult<CustomerModel>> GetCustomerAsync(long id)
        {
            var customerDto = await _customerService.GetAsync(id);
            if (customerDto == null)
                return NotFound();

            return Ok(_mapper.Map<CustomerDto>(customerDto));
        }

        [HttpPost("")]   
        public async Task<ActionResult<long>> CreateCustomerAsync(CustomerModel customerModel)
        {
            if (customerModel.Id.HasValue && await _customerService.GetAsync(customerModel.Id.Value) != null)
                return Conflict();

            var customerDto = _mapper.Map<CustomerDto>(customerModel);
            return await _customerService.AddAsync(customerDto);
        }
    }
}