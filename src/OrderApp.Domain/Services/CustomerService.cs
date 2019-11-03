using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Add(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Name) || string.IsNullOrEmpty(customer.Email)) return false;

            var existentCustomerEmail = await _customerRepository.Search(c => c.Email == customer.Email);
            if (existentCustomerEmail.Any()) return false;

            await _customerRepository.Add(customer);
            return true;
        }

        public void Dispose()
        {
            _customerRepository?.Dispose();
        }
    }
}