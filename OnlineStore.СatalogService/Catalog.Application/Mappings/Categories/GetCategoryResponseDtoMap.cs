using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Categories;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings.Categories
{
    internal class GetCategoryResponseDtoMap : Profile
    {
        public GetCategoryResponseDtoMap()
        {
            CreateMap<Category, GetCategoryResponseDto>()
                .ForMember(categoryDto => categoryDto.Id,
                    opt => opt.MapFrom(entityCategory => entityCategory.Id))
                .ForMember(categoryDto => categoryDto.Title,
                    opt => opt.MapFrom(entityCategory => entityCategory.Title));
        }
    }
}