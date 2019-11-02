using System;

namespace OrderApp.Domain.Models
{
    public class Order : Entity
    {
        public Guid CustomerId { get; set; }

        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

        /* EF Relation */
        public Customer Customer { get; set; }
    }
}
