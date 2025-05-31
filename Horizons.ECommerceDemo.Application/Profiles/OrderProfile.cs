using AutoMapper;
using Horizons.ECommerceDemo.Application.Dtos;
using Horizons.ECommerceDemo.Domain.Entites;
using Horizons.ECommerceDemo.Domain.Entites.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Application.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalPrice.Amount))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.TotalPrice.Currency))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));
                

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Amount))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Price.Currency))
                .ForMember(dest => dest.ProductRef, opt => opt.MapFrom(src => src.ProductRef));
        }
    }
}

