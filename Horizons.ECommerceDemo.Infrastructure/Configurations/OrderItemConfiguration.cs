using Horizons.ECommerceDemo.Domain.Entites;
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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {

            builder.Property(x=>x.Id).ValueGeneratedNever();
                builder.OwnsOne(i => i.Price, money =>
                {
                    money.Property(m => m.Amount);
                    money.Property(m => m.Currency);
                });
            
        }
    }
}
