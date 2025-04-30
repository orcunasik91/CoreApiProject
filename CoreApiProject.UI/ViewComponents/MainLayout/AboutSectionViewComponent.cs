using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.UI.ViewComponents.MainLayout;
public class AboutSectionViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}