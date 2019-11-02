using System;
using System.ComponentModel.DataAnnotations;

namespace OrderApp.API.Dtos
{
    public class CustomerDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
