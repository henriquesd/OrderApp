using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderApp.API.Dtos;
using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;

namespace OrderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository,
                                     ICustomerService customerService,
                                    IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerDto>>(await _customerRepository.GetAll());
        }

        [HttpGet("CustomerOrders/{id:guid}")]
        public async Task<ActionResult<CustomerOrdersDto>> GetCustomersOrders(Guid id)
        {
            var customerOrders = await _customerRepository.GetCustomersOrders(id);

            return _mapper.Map<CustomerOrdersDto>(customerOrders);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Add(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var customer = _mapper.Map<Customer>(customerDto);
            var result = await _customerService.Add(customer);

            if (!result) return BadRequest();

            return Ok(customer);
        }
    }
}