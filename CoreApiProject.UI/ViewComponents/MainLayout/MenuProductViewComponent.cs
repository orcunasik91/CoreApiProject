using CoreApiProject.UI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreApiProject.UI.ViewComponents.MainLayout;
public class MenuProductViewComponent : ViewComponent
{
    private readonly IHttpClientFactory httpClientFactory;
    public MenuProductViewComponent(IHttpClientFactory _httpClientFactory)
    {
        httpClientFactory = _httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7026/api/Products/ProductsWithCategory");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductsWithCategoryDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}