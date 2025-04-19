using AutoMapper;
using InventifyBackend.Application.Dtos.Categories;
using InventifyBackend.Application.Dtos.Customers;
using InventifyBackend.Application.Dtos.Product;
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

            #region Category mapping
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryCreateResource, Category>();
            CreateMap<CategoryCreateResource, CategoryDto>();
            #endregion Category mapping

            #region Customer mapping
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerCreateResource, Customer>();
            CreateMap<CustomerCreateResource, CustomerDto>();
            #endregion Customer mapping
            
            #region Product mapping
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductCreateResource, Product>();
            CreateMap<ProductCreateResource, ProductDto>();
            CreateMap<ProductUpdateResource, Product>();
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            #endregion Product mapping
        }
    }
}
