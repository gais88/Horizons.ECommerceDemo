using Horizons.ECommerceDemo.Domain.Entites;
using Horizons.ECommerceDemo.Domain.Entites.Aggregates;
using Horizons.ECommerceDemo.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            
          

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).HasConversion(
                e => e.Value,
                value => new Email(value));
            builder.HasMany(x=>x.Orders).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
           
        }
    }
}
