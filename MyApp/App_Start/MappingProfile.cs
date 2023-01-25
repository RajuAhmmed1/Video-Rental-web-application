using AutoMapper;
using MyApp.DTOS;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customers, CustomerDtos>();
          
            Mapper.CreateMap<Movies, MovieDtos>();
          
            Mapper.CreateMap<Genres, GenreDtos>();
            Mapper.CreateMap<MemberShipTypes, MemberShipTypeDtos>();


            Mapper.CreateMap<CustomerDtos, Customers>()
                .ForMember(c => c.ID, opt => opt.Ignore());

            Mapper.CreateMap<MovieDtos, Movies>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}