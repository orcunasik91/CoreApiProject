using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.UI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}