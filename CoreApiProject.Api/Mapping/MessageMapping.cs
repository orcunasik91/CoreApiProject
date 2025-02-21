using AutoMapper;
using CoreApiProject.Api.Dtos.MessageDtos;
using CoreApiProject.Api.Entities;

namespace CoreApiProject.Api.Mapping;
public class MessageMapping : Profile
{
    public MessageMapping()
    {
        CreateMap<CreateMessageDto, Message>().ReverseMap();
        CreateMap<ResultMessageDto, Message>().ReverseMap();
        CreateMap<UpdateMessageDto, Message>().ReverseMap();
        CreateMap<GetByIdMessageDto, Message>().ReverseMap();
    }
}