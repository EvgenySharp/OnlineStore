using AutoMapper;
using Catalog.Application.DTOs.RequestDtos.Categories;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings.Categories
{
    internal class CategoryEntityMap : Profile
    {
        public CategoryEntityMap()
        {
            CreateMap<CreateCategoryRequestDto, Category>()
                .ForMember(entityCategory => entityCategory.Title,
                    opt => opt.MapFrom(categoryDto => categoryDto.Title));
        }
    }
}