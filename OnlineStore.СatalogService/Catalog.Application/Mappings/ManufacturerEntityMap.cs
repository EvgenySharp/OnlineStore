using AutoMapper;
using Catalog.Application.Manufacturers.Commands.CreateManufacturer;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings
{
    internal class ManufacturerEntityMap : Profile
    {
        public ManufacturerEntityMap() 
        {
            CreateMap<CreateManufacturerCommand, Manufacturer>()
                .ForMember(entityManufacturer => entityManufacturer.Title,
                    opt => opt.MapFrom(manufacturerDto => manufacturerDto.ManufacturerTitle));
        }
    }
}