using AutoMapper;
using CoreApiProject.Api.Dtos.ChefDtos;
using CoreApiProject.Api.Entities;

namespace CoreApiProject.Api.Mapping;
public class ChefMapping : Profile
{
    public ChefMapping()
    {
        CreateMap<CreateChefDto, Chef>().ReverseMap();
        CreateMap<UpdateChefDto, Chef>().ReverseMap();
        CreateMap<ResultChefDto, Chef>().ReverseMap();
        CreateMap<GetByIdChefDto, Chef>().ReverseMap();
    }
}