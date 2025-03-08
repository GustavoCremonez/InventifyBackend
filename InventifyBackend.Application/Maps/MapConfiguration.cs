using AutoMapper;
using InventifyBackend.Application.Dtos.Categories;
using InventifyBackend.Application.Dtos.Customers;
using InventifyBackend.Application.Dtos.User;
using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Application.Maps
{
    public sealed class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            #region User mapping
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserCreateResource, User>();
            CreateMap<UserCreateResource, UserDto>();
            #endregion User mapping

            #region Categorie mapping
            CreateMap<Categorie, CategorieDto>().ReverseMap();
            CreateMap<CategorieCreateResource, Categorie>();
            CreateMap<CategorieCreateResource, CategorieDto>();
            #endregion Categorie mapping

            #region Customer mapping
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerCreateResource, Customer>();
            CreateMap<CustomerCreateResource, CustomerDto>();
            #endregion Customer mapping
        }
    }
}
