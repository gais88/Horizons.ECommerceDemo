using Horizons.ECommerceDemo.Domain.Entites;
using Horizons.ECommerceDemo.Domain.ValueObjects;
using Horizons.ECommerceDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Infrastructure.DataSeeds
{
    public class SeedCustomers
    {
        public static async Task SeedCustomersAsync(AppDbContext dbContext)
        {
            if (await dbContext.Customers.AnyAsync())
            {
                return;
            }

            var customers = new List<Customer>()
            {
                new Customer("test customer 1",new Email("test@example.com")),
                new Customer("test customer 2",new Email("test2@example.com")),
            };

            await dbContext.AddRangeAsync(customers);
            await dbContext.SaveChangesAsync();
        }
    }
}
