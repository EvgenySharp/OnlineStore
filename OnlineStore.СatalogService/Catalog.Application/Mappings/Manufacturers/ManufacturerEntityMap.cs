using AutoMapper;
using Catalog.Application.DTOs.RequestDtos.Manufacturers;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings.Manufacturers
{
    internal class ManufacturerEntityMap : Profile
    {
        public ManufacturerEntityMap()
        {
            CreateMap<CreateManufacturerRequestDto, Manufacturer>()
                .ForMember(entityManufacturer => entityManufacturer.Title,
                    opt => opt.MapFrom(manufacturerDto => manufacturerDto.Title));
        }
    }
}