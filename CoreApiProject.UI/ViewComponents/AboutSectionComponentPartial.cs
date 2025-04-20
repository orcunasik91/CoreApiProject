using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.UI.ViewComponents;
public class AboutSectionComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}