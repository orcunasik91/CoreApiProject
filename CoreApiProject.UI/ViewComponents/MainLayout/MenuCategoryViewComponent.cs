using CoreApiProject.UI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreApiProject.UI.ViewComponents.MainLayout;
public class MenuCategoryViewComponent : ViewComponent
{
    private readonly IHttpClientFactory httpClientFactory;
    public MenuCategoryViewComponent(IHttpClientFactory _httpClientFactory)
    {
        httpClientFactory = _httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7026/api/Categories");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}