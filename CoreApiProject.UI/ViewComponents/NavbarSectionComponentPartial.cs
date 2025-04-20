using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.UI.ViewComponents;
public class NavbarSectionComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
