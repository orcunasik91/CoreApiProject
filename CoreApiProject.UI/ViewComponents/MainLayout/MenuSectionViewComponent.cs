using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.UI.ViewComponents.MainLayout;
public class MenuSectionViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();

    }
}