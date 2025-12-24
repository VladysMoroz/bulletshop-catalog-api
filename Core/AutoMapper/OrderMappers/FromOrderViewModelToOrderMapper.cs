using AutoMapper;
using Core.Entities;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AutoMapper.OrderMappers
{
    public class FromOrderViewModelToOrderMapper : Profile
    {
        public FromOrderViewModelToOrderMapper()
        {
            CreateMap<OrderViewModel, Order>()
                   .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<OrderDetailsViewModel, OrderDetails>();
        }
    }
}
