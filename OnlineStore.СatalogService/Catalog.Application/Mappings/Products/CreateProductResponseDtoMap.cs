using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Products;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings.Products
{
    public class CreateProductResponseDtoMap : Profile
    {
        public CreateProductResponseDtoMap() 
        {
            CreateMap<Product, CreateProtuctResponseDto>()
                .ForMember(productDto => productDto.Title,
                    opt => opt.MapFrom(entityProduct => entityProduct.Title));
        }
    }
}