using AutoMapper;
using Core.Entities;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AutoMapper.PreferenceMappers
{
    public class FromPreferenceViewModelToPreferenceMapper : Profile
    {
        public FromPreferenceViewModelToPreferenceMapper()
        {
            CreateMap<PreferenceViewModel, Preference>()

                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}
