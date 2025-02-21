using AutoMapper;
using CoreApiProject.Api.Dtos.FeatureDtos;
using CoreApiProject.Api.Entities;

namespace CoreApiProject.Api.Mapping;
public class FeatureMapping : Profile
{
    public FeatureMapping()
    {
        CreateMap<CreateFeatureDto, Feature>().ReverseMap();
        CreateMap<ResultFeatureDto, Feature>().ReverseMap();
        CreateMap<UpdateFeatureDto, Feature>().ReverseMap();
        CreateMap<GetByIdFeatureDto, Feature>().ReverseMap();
    }
}