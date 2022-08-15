using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefNDishes.Models;

public class ChefController : Controller
{
    private MyContext  _context;

    private int? uid
    {
        get{
            return HttpContext.Session.GetInt32("UUID");
        }
    }

    
    // here we can "inject" our context service into the constructor
    public ChefController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/")]
    [HttpGet("/allchefs")]
    public IActionResult All()
    {
        List<Chef> AllChef = _context.Chefs
        .Include(chef => chef.CreatedDishes).ToList();

        return View("AllChefs", AllChef);
    }


    [HttpGet("/new")]
    public IActionResult New()
    {
        return View("NewChef");
    }


    [HttpPost("/new")]
    public IActionResult Create( Chef newChef)
    {
        if (ModelState.IsValid == false)
        {
            return New();
        }
        _context.Chefs.Add(newChef);
        _context.SaveChanges();
        return RedirectToAction("All");
    }

}