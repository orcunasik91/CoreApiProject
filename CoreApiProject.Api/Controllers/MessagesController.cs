using AutoMapper;
using CoreApiProject.Api.Context;
using CoreApiProject.Api.Dtos.FeatureDtos;
using CoreApiProject.Api.Dtos.MessageDtos;
using CoreApiProject.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly ApiContext context;
    private readonly IMapper mapper;

    public MessagesController(ApiContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }
    [HttpGet]
    public IActionResult GetMessages()
    {
        List<Message> messages = context.Messages.ToList();
        List<ResultMessageDto> messagesDto = mapper.Map<List<ResultMessageDto>>(messages);
        return Ok(messagesDto);
    }
    [HttpGet("GetMessage")]
    public IActionResult GetMessage(int id)
    {
        var message = context.Features.Find(id);
        GetByIdMessageDto messageDto = mapper.Map<GetByIdMessageDto>(message);
        return Ok(messageDto);
    }
    [HttpPost]
    public IActionResult CreateMessage(CreateMessageDto messageDto)
    {
        Message message = mapper.Map<Message>(messageDto);
        context.Messages.Add(message);
        context.SaveChanges();
        return Ok("Mesaj Bilgisi Ekleme İşlemi Başarılı");
    }
    [HttpDelete]
    public IActionResult RemoveMessage(int id)
    {
        var message = context.Messages.Find(id);
        if (message is not null)
        {
            context.Messages.Remove(message);
            context.SaveChanges();
            return Ok("Mesaj Bilgisi Silme İşlemi Başarılı");
        }
        else
            return BadRequest("Silinecek Mesaj Bilgisi Bulunamadı!");
    }
    [HttpPut]
    public IActionResult UpdateMessage(UpdateMessageDto messageDto)
    {
        Message message = mapper.Map<Message>(messageDto);
        context.Messages.Update(message);
        context.SaveChanges();
        return Ok("Mesaj Bilgisi Güncellendi");
    }
}