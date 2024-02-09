using AutoMapper;
using Catalog.Application.DTOs.RequestDtos;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings
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