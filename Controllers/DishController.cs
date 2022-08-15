using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace
ChefNDishes.Models;

public class DishController : Controller
{
    private MyContext  _context;

    private int? uid
    {
        get{
            return HttpContext.Session.GetInt32("UUID");
        }
    }

    
    // here we can "inject" our context service into the constructor
    public DishController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/dishes")]
    public IActionResult AllDishes()
    {
        List<Dish> AllDishes = _context.Dishes
        .Include(d => d.Creator).ToList();
        return View("AllDishes", AllDishes);

    }

    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        ViewBag.AllChefsStorage = _context.Chefs.ToList();
        return View("NewDish");
    }

    [HttpPost("dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid == false)
        {
            return NewDish();
        }
        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("AllDishes");
    }


}