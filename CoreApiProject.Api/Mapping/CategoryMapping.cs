using AutoMapper;
using CoreApiProject.Api.Dtos.CategoryDtos;
using CoreApiProject.Api.Entities;

namespace CoreApiProject.Api.Mapping;
public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<CreateCategoryDto, Category>().ReverseMap();
        CreateMap<ResultCategoryDto, Category>().ReverseMap();
        CreateMap<UpdateCategoryDto, Category>().ReverseMap();
    }
}
