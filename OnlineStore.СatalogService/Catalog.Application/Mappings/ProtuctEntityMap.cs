using AutoMapper;
using Catalog.Application.DTOs.RequestDtos;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings
{
    internal class ProtuctEntityMap : Profile
    {
        public ProtuctEntityMap() 
        {
            CreateMap<CreateProtuctRequestDto, Product>()                
                .ForMember(entityProtuct => entityProtuct.Title,
                    opt => opt.MapFrom(protuctDto => protuctDto.Title));
        }
    }
}