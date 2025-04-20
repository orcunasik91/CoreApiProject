using AutoMapper;
using CoreApiProject.Api.Context;
using CoreApiProject.Api.Dtos.CategoryDtos;
using CoreApiProject.Api.Dtos.ServiceDtos;
using CoreApiProject.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly ApiContext context;
    private readonly IMapper mapper;

    public ServicesController(ApiContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }
    [HttpGet]
    public IActionResult GetServices()
    {
        List<Service> services = context.Services.ToList();
        List<ResultServiceDto> servicesDto = mapper.Map<List<ResultServiceDto>>(services);
        return Ok(servicesDto);
    }
    [HttpGet("GetService")]
    public IActionResult GetService(int id)
    {
        var service = context.Services.Find(id);
        GetByIdServiceDto serviceDto = mapper.Map<GetByIdServiceDto>(service);
        return Ok(serviceDto);
    }
    [HttpPost]
    public IActionResult CreateService(CreateServiceDto serviceDto)
    {
        Service service = mapper.Map<Service>(serviceDto);
        context.Services.Add(service);
        context.SaveChanges();
        return Ok("Hizmet Ekleme İşlemi Başarılı");
    }
    [HttpDelete]
    public IActionResult RemoveService(int id)
    {
        var service = context.Services.Find(id);
        if (service is not null)
        {
            context.Services.Remove(service);
            context.SaveChanges();
            return Ok("Hizmet Silme İşlemi Başarılı");
        }
        else
            return BadRequest("Hizmet Bulunamadı!");
    }
    [HttpPut]
    public IActionResult UpdateService(UpdateServiceDto serviceDto)
    {
        Service service = mapper.Map<Service>(serviceDto);
        context.Services.Update(service);
        context.SaveChanges();
        return Ok("Hizmet Güncellendi");
    }
}