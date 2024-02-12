using AutoMapper;
using Catalog.Application.DTOs.RequestDtos.Products;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings.Products
{
    internal class ProtuctEntityMap : Profile
    {
        public ProtuctEntityMap()
        {
            CreateMap<CreateProductRequestDto, Product>()
                .ForMember(entityProtuct => entityProtuct.Title,
                    opt => opt.MapFrom(productForMap => productForMap.Title))
                .ForMember(entityProtuct => entityProtuct.CategoryId,
                    opt => opt.MapFrom(productForMap => productForMap.CategoryId))
                .ForMember(entityProtuct => entityProtuct.ManufacturerId,
                    opt => opt.MapFrom(productForMap => productForMap.ManufacturerId));

        }
    }
}