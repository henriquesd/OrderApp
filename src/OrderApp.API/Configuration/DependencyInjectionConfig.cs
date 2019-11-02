using Microsoft.Extensions.DependencyInjection;
using OrderApp.Domain.Interfaces;
using OrderApp.Infrastructure.Context;
using OrderApp.Infrastructure.Repository;

namespace OrderApp.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<OrderAppDbContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
