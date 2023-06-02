using MicroServiceTemplate.Data.Repositories;
using MicroServiceTemplate.Data.Services;

namespace MicroServiceTemplate.Api.DependencyInjections
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }

        public static IServiceCollection AddDependencyRepositories(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
