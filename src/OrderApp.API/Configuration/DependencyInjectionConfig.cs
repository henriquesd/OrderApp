using Microsoft.Extensions.DependencyInjection;
using OrderApp.Infrastructure.Context;

namespace OrderApp.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<OrderAppDbContext>();

            return services;
        }
    }
}
