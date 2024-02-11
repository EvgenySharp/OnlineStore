using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Manufacturers;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings.Manufacturers
{
    internal class CreateManufacturerResponseDtoMap : Profile
    {
        public CreateManufacturerResponseDtoMap()
        {
            CreateMap<Manufacturer, CreateManufacturerResponseDto>()
                .ForMember(manufacturerDto => manufacturerDto.Title,
                    opt => opt.MapFrom(entityManufacturer => entityManufacturer.Title));
        }
    }
}