using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Manufacturers;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings.Manufacturers
{
    internal class GetManufacturerResponseDtoMap : Profile
    {
        public GetManufacturerResponseDtoMap()
        {
            CreateMap<Manufacturer, GetManufacturerResponseDto>()
                .ForMember(manufacturerDto => manufacturerDto.Id,
                    opt => opt.MapFrom(entityManufacturer => entityManufacturer.Id))
                .ForMember(manufacturerDto => manufacturerDto.Title,
                    opt => opt.MapFrom(entityManufacturer => entityManufacturer.Title));
        }
    }
}