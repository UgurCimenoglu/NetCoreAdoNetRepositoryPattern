using AdoNetDeneme.Entities.Dtos;
using AdoNetDeneme.Entities.Entites;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetDeneme.Entities.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, DtoUser>().ReverseMap();
        }
    }
}
