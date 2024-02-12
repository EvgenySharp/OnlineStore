using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Products;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings.Products
{
    public class GetProductResponseDtoMap : Profile
    {
        public GetProductResponseDtoMap()
        {
            CreateMap<Product, GetProductResponseDto>()
                .ForMember(productDto => productDto.Id,
                    opt => opt.MapFrom(entityProduct => entityProduct.Id))
                .ForMember(productDto => productDto.Title,
                    opt => opt.MapFrom(entityProduct => entityProduct.Title))
                .ForMember(productDto => productDto.CategoryId,
                    opt => opt.MapFrom(entityProduct => entityProduct.CategoryId))
                .ForMember(productDto => productDto.ManufacturerId,
                    opt => opt.MapFrom(entityProduct => entityProduct.ManufacturerId));
        }
    }
}