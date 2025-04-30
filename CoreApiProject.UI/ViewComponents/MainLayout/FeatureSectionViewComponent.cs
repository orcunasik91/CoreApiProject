using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.UI.ViewComponents.MainLayout;
public class FeatureSectionViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
