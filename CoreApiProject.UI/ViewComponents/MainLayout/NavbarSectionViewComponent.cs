using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.UI.ViewComponents.MainLayout;
public class NavbarSectionViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
