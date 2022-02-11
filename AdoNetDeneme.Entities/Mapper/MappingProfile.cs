using AdoNet.Entities.Dtos;
using AdoNet.Entities.Entites;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.Entities.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, DtoUserRegister>().ReverseMap();
        }
    }
}
