using System;
using System.ComponentModel.DataAnnotations;

namespace OrderApp.API.Dtos
{
    public class OrderDto
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
    }
}
