using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers;

public class AdminController : UserController
{
    public IActionResult Index()
    {
        return View();
    }
}