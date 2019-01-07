using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WidlyApp2.Dtos;
using WidlyApp2.Models;

namespace WidlyApp2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }

    }
}