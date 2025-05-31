using Horizons.ECommerceDemo.Domain.Entites;
using Horizons.ECommerceDemo.Domain.Entites.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

          

            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           

            // Suppress the warning if needed (not recommended for production)
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

    }
}
