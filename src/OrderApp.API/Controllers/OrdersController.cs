using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderApp.API.Dtos;
using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> Add(OrderDto orderDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var order = _mapper.Map<Order>(orderDto);
            order.CreatedDate = DateTime.Now;

            var result = await _orderService.Add(order);

            if (!result) return BadRequest();

            return Ok(order);
        }
    }
}