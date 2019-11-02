using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderApp.API.Dtos
{
    public class CustomerOrdersDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
