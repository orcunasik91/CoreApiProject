using AutoMapper;
using CoreApiProject.Api.Context;
using CoreApiProject.Api.Dtos.ContactDtos;
using CoreApiProject.Api.Dtos.FeatureDtos;
using CoreApiProject.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeaturesController : ControllerBase
{
    private readonly ApiContext context;
    private readonly IMapper mapper;

    public FeaturesController(ApiContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }
    [HttpGet]
    public IActionResult GetFeatures()
    {
        List<Feature> features = context.Features.ToList();
        List<ResultFeatureDto> featuresDto = mapper.Map<List<ResultFeatureDto>>(features);
        return Ok(featuresDto);
    }
    [HttpGet("GetFeature")]
    public IActionResult GetFeature(int id)
    {
        var feature = context.Features.Find(id);
        GetByIdFeatureDto featureDto = mapper.Map<GetByIdFeatureDto>(feature);
        return Ok(featureDto);
    }
    [HttpPost]
    public IActionResult CreateFeature(CreateFeatureDto featureDto)
    {
        Feature feature = mapper.Map<Feature>(featureDto);
        context.Features.Add(feature);
        context.SaveChanges();
        return Ok("Feature Bilgisi Ekleme İşlemi Başarılı");
    }
    [HttpDelete]
    public IActionResult RemoveFeature(int id)
    {
        var feature = context.Features.Find(id);
        if (feature is not null)
        {
            context.Features.Remove(feature);
            context.SaveChanges();
            return Ok("Feature Bilgisi Silme İşlemi Başarılı");
        }
        else
            return BadRequest("Silinecek Feature Bilgisi Bulunamadı!");
    }
    [HttpPut]
    public IActionResult UpdateFeature(UpdateFeatureDto featureDto)
    {
        Feature feature = mapper.Map<Feature>(featureDto);
        context.Features.Update(feature);
        context.SaveChanges();
        return Ok("Feature Bilgisi Güncellendi");
    }
}