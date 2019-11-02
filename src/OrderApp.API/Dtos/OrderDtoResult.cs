using OrderApp.Domain.Models;
using System;

namespace OrderApp.API.Dtos
{
    public class OrderDtoResult
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

        /* EF Relation */
        public Customer Customer { get; set; }
    }
}
