using AutoMapper;
using CoreApiProject.Api.Dtos.ContactDtos;
using CoreApiProject.Api.Entities;

namespace CoreApiProject.Api.Mapping;
public class ContactMapping : Profile
{
    public ContactMapping()
    {
        CreateMap<CreateContactDto, Contact>().ReverseMap();
        CreateMap<ResultContactDto, Contact>().ReverseMap();
        CreateMap<UpdateContactDto, Contact>().ReverseMap();
        CreateMap<GetByIdContactDto, Contact>().ReverseMap();
    }
}