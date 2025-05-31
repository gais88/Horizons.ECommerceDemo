using Horizons.ECommerceDemo.Domain.Interfaces;
using Horizons.ECommerceDemo.Infrastructure.Data;
using Horizons.ECommerceDemo.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Infrastructure
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            

            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();


            return services;
        }
    }

}
