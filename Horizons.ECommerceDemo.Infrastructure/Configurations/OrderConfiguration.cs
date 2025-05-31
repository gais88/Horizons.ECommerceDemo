using Horizons.ECommerceDemo.Domain.Entites.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x=>x.Id).ValueGeneratedNever();
            builder.Property(o => o.Status)
                .HasConversion<string>();
            builder.OwnsOne(o => o.TotalPrice, money =>
            {

                money.Property(x => x.Amount);
                money.Property(m => m.Currency);
            });
            builder.HasMany(o => o.OrderItems)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);
           
        }
    }
}
