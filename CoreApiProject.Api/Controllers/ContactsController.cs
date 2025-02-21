using AutoMapper;
using CoreApiProject.Api.Context;
using CoreApiProject.Api.Dtos.ChefDtos;
using CoreApiProject.Api.Dtos.ContactDtos;
using CoreApiProject.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly ApiContext context;
    private readonly IMapper mapper;

    public ContactsController(ApiContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }
    [HttpGet]
    public IActionResult GetContacts()
    {
        List<Contact> contacts = context.Contacts.ToList();
        List<ResultContactDto> contactsDto = mapper.Map<List<ResultContactDto>>(contacts);
        return Ok(contactsDto);
    }
    [HttpGet("GetContact")]
    public IActionResult GetContact(int id)
    {
        var contact = context.Contacts.Find(id);
        GetByIdContactDto contactDto = mapper.Map<GetByIdContactDto>(contact);
        return Ok(contactDto);
    }
    [HttpPost]
    public IActionResult CreateContact(CreateContactDto contactDto)
    {
        Contact contact = mapper.Map<Contact>(contactDto);
        context.Contacts.Add(contact);
        context.SaveChanges();
        return Ok("İletişim Bilgisi Ekleme İşlemi Başarılı");
    }
    [HttpDelete]
    public IActionResult RemoveContact(int id)
    {
        var contact = context.Contacts.Find(id);
        if (contact is not null)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return Ok("İletişim Bilgisi Silme İşlemi Başarılı");
        }
        else
            return BadRequest("Silinecek İletişim Bilgisi Bulunamadı!");
    }
    [HttpPut]
    public IActionResult UpdateContact(UpdateContactDto contactDto)
    {
        Contact contact = mapper.Map<Contact>(contactDto);
        context.Contacts.Update(contact);
        context.SaveChanges();
        return Ok("İletişim Bilgisi Güncellendi");
    }
}