using AutoMapper;
using OrderApp.API.Dtos;
using OrderApp.Domain.Models;

namespace OrderApp.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Customer, CustomerOrdersDto>().ReverseMap();
        }
    }
}
