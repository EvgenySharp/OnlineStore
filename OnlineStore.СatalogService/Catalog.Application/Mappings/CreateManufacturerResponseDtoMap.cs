using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings
{
    internal class CreateManufacturerResponseDtoMap : Profile
    {
        public CreateManufacturerResponseDtoMap()
        {
            CreateMap<Manufacturer, ManufacturerResponseDto>()
                .ForMember(manufacturerDto => manufacturerDto.Title,
                    opt => opt.MapFrom(entityManufacturer => entityManufacturer.Title));
        }
    }
}