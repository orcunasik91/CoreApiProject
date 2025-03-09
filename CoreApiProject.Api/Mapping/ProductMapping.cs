using AutoMapper;
using CoreApiProject.Api.Dtos.ProductDtos;
using CoreApiProject.Api.Entities;

namespace CoreApiProject.Api.Mapping;
public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<CreateProductDto, Product>().ReverseMap();
        CreateMap<ResultProductDto, Product>().ReverseMap();
        CreateMap<UpdateProductDto, Product>().ReverseMap();
        CreateMap<GetByIdProductDto, Product>().ReverseMap();
    }
}