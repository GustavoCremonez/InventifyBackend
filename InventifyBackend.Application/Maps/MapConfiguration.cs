using AutoMapper;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Application.Maps
{
    public sealed class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserCreateResource, User>();
            CreateMap<UserCreateResource, UserDto>();
        }
    }
}
