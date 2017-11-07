using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelApp.Contracts.DTO;
using TravelApp.Entities.Model;

namespace TravelApp.Web.App_Start
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Attraction, AttractionDto>().MaxDepth(1);
            CreateMap<AttractionDto, Attraction>().MaxDepth(1);
            CreateMap<Country, CountryDto>().MaxDepth(1) ;
            CreateMap<City, CityDto>().MaxDepth(1);
            CreateMap<CityDto,City>().MaxDepth(1);
            CreateMap<TripPlan, TripPlanDto>().MaxDepth(1);
            CreateMap<Comment, CommentDto>().MaxDepth(1); 
            CreateMap<Blog, BlogDto>().MaxDepth(1);
            CreateMap<Blog, BlogSlicedDto>().MaxDepth(1);
            CreateMap<UserInfo,UserDto>().MaxDepth(1);
            CreateMap<Favourite, FavouriteDto>().MaxDepth(1);
            CreateMap<Rank, RankDto>().MaxDepth(1);
        }
    }
}