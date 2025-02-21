using AutoMapper;
using CoreApiProject.Api.Context;
using CoreApiProject.Api.Dtos.CategoryDtos;
using CoreApiProject.Api.Dtos.ChefDtos;
using CoreApiProject.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChefsController : ControllerBase
{
    private readonly ApiContext context;
    private readonly IMapper mapper;

    public ChefsController(ApiContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }
    [HttpGet]
    public IActionResult GetChefs()
    {
        List<Chef> chefs = context.Chefs.ToList();
        List<ResultChefDto> chefsDto = mapper.Map<List<ResultChefDto>>(chefs);
        return Ok(chefsDto);
    }
    [HttpGet("GetChef")]
    public IActionResult GetChef(int id)
    {
        var chef = context.Chefs.Find(id);
        GetByIdChefDto chefDto = mapper.Map<GetByIdChefDto>(chef);
        return Ok(chefDto);
    }
    [HttpPost]
    public IActionResult CreateChef(CreateChefDto chefDto)
    {
        Chef chef = mapper.Map<Chef>(chefDto);
        context.Chefs.Add(chef);
        context.SaveChanges();
        return Ok("Şef Ekleme İşlemi Başarılı");
    }
    [HttpDelete]
    public IActionResult RemoveChef(int id)
    {
        var chef = context.Chefs.Find(id);
        if (chef is not null)
        {
            context.Chefs.Remove(chef);
            context.SaveChanges();
            return Ok("Şef Silme İşlemi Başarılı");
        }
        else
            return BadRequest("Silinecek Şef Bulunamadı!");
    }
    [HttpPut]
    public IActionResult UpdateChef(UpdateChefDto chefDto)
    {
        Chef chef = mapper.Map<Chef>(chefDto);
        context.Chefs.Update(chef);
        context.SaveChanges();
        return Ok("Şef Bilgisi Güncellendi");
    }
}
