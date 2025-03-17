using AutoMapper;
using CoreApiProject.Api.Context;
using CoreApiProject.Api.Dtos.ProductDtos;
using CoreApiProject.Api.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApiProject.Api.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ApiContext context;
    private readonly IValidator<CreateProductDto> createProductValidator;
    private readonly IMapper mapper;

    public ProductsController(ApiContext _context, IValidator<CreateProductDto> _createProductValidator, IMapper _mapper)
    {
        context = _context;
        createProductValidator = _createProductValidator;
        mapper = _mapper;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        List<Product> products = context.Products.ToList();
        List<ResultProductDto> productsDto = mapper.Map<List<ResultProductDto>>(products);
        return Ok(productsDto);
    }

    [HttpGet("ProductsWithCategory")]
    public IActionResult GetProductsWithCategory()
    {
        List<Product> products = context.Products.Include(p => p.Category).ToList();
        List<ResultProductWithCategoryDto> productsDto = mapper.Map<List<ResultProductWithCategoryDto>>(products);
        return Ok(productsDto);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetProduct([FromRoute(Name = "id")]int id)
    {
        var product = context.Products.Find(id);
        GetByIdProductDto productDto = mapper.Map<GetByIdProductDto>(product);
        return Ok(productDto);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateProductDto productDto)
    {
        var validationResult = createProductValidator.Validate(productDto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        Product product = mapper.Map<Product>(productDto);
        context.Products.Add(product);
        context.SaveChanges();
        return Ok(new {message = "Ürün Başarıyla Eklendi", data = product});
    }

    [HttpDelete("{id:int}")]
    public IActionResult RemoveProduct([FromRoute(Name = "id")] int id)
    {
        var product = context.Products.Find(id);
        if (product != null)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return Ok("Ürün Başarıyla Kaldırıldı");
        }
        else
            return NotFound("Ürün Bulunamadı");
    }

    [HttpPut]
    public IActionResult UpdateProduct([FromBody] UpdateProductDto productDto)
    {
        Product product = mapper.Map<Product>(productDto);
        context.Products.Update(product);
        context.SaveChanges();
        return Ok("Ürün Başarıyla Güncellendi");
    }
}