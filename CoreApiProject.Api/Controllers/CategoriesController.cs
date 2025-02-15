using AutoMapper;
using CoreApiProject.Api.Context;
using CoreApiProject.Api.Dtos.CategoryDtos;
using CoreApiProject.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ApiContext context;
    private readonly IMapper mapper;

    public CategoriesController(ApiContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }
    [HttpGet]
    public IActionResult GetCategories()
    {
        List<Category> categories = context.Categories.ToList();
        List<ResultCategoryDto> categoriesDto = mapper.Map<List<ResultCategoryDto>>(categories);
        return Ok(categoriesDto);
    }
    [HttpGet("GetCategory")]
    public IActionResult GetCategory(int id)
    {
        var category = context.Categories.Find(id);
        ResultCategoryDto categoryDto = mapper.Map<ResultCategoryDto>(category);
        return Ok(categoryDto);
    }
    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryDto categoryDto)
    {
        Category category = mapper.Map<Category>(categoryDto);
        context.Categories.Add(category);
        context.SaveChanges();
        return Ok("Kategori Ekleme İşlemi Başarılı");
    }
    [HttpDelete]
    public IActionResult RemoveCategory(int id)
    {
        var category = context.Categories.Find(id);
        if(category is not null)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
            return Ok("Kategori Silme İşlemi Başarılı");
        }
        else
            return BadRequest("Kategori Bulunamadı!");
    }
    [HttpPut]
    public IActionResult UpdateCategory(UpdateCategoryDto categoryDto)
    {
        Category category = mapper.Map<Category>(categoryDto);
        category.CategoryId = categoryDto.CategoryId;
        category.CategoryName = categoryDto.CategoryName;
        context.Categories.Update(category);
        context.SaveChanges();
        return Ok("Kategori Güncellendi");
    }
}