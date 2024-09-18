using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}