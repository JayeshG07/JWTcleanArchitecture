using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using System.Runtime;

namespace Domain.Configuration
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            CreateMap<User, RegisterUserDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
