using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Categories;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings.Categories
{
    internal class CreateCategoryResponseDtoMap : Profile
    {
        public CreateCategoryResponseDtoMap()
        {
            CreateMap<Category, CreateCategoryResponseDto>()
                .ForMember(categoryDto => categoryDto.Title,
                    opt => opt.MapFrom(entityCategory => entityCategory.Title));
        }
    }
}