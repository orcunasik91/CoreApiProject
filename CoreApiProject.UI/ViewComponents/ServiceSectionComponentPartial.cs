using CoreApiProject.UI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreApiProject.UI.ViewComponents;
public class ServiceSectionComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory httpClientFactory;

    public ServiceSectionComponentPartial(IHttpClientFactory _httpClientFactory)
    {
        httpClientFactory = _httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7026/api/Services");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}