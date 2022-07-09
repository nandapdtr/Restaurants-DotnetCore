using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OdeToFood.Core;

namespace OdeToFood
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantModel>()
                .ForMember(o => o.RestaurantId, ex => ex.MapFrom(o => o.Id))
                .ForMember(o => o.RestaurantName, ex => ex.MapFrom(o => o.Name))
                .ReverseMap();
        }
    }
}
