using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;

namespace ChefNDishes.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


}
