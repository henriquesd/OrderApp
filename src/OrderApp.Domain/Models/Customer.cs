using System.Collections.Generic;

namespace OrderApp.Domain.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        /* EF Relations */
        public IEnumerable<Order> Orders { get; set; }
    }
}
