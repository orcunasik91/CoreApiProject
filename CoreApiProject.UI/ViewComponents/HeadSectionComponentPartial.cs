using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.UI.ViewComponents;
public class HeadSectionComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
