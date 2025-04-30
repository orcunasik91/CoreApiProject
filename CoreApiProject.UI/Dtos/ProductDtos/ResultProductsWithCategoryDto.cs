namespace CoreApiProject.UI.Dtos.ProductDtos;
public class ResultProductsWithCategoryDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryName { get; set; }
}