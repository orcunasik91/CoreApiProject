using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.UI.ViewComponents;
public class FeatureSectionComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
