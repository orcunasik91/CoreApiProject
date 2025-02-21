namespace CoreApiProject.Api.Dtos.FeatureDtos;
public class GetByIdFeatureDto
{
    public int FeatureId { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string ShortDescription { get; set; }
    public string ImageUrl { get; set; }
    public string VideoUrl { get; set; }
}