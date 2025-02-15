using CoreApiProject.Api.Entities;

namespace CoreApiProject.Api.Dtos.CategoryDtos;
public class UpdateCategoryDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}