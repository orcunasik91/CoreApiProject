using AutoMapper;
using CoreApiProject.Api.Dtos.ServiceDtos;
using CoreApiProject.Api.Entities;

namespace CoreApiProject.Api.Mapping;
public class ServiceMapping : Profile
{
    public ServiceMapping()
    {
        CreateMap<CreateServiceDto, Service>().ReverseMap();
        CreateMap<ResultServiceDto, Service>().ReverseMap();
        CreateMap<UpdateServiceDto, Service>().ReverseMap();
        CreateMap<GetByIdServiceDto, Service>().ReverseMap();
    }
}
