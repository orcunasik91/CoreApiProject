using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.UI.ViewComponents.MainLayout;
public class HeadSectionViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
