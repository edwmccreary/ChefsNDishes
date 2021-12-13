using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;
//added
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            GetChefsDishes();
            return View();
        }

        [HttpGet("Dishes")]
        public IActionResult Dishes()
        {
            GetDishes();
            return View("Dishes");
        }

        [HttpGet("new_chef")]
        public IActionResult NewChef()
        {
            return View("AddChef");
        }

        [HttpPost("add_chef")]
        public IActionResult AddChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                //newChef.GetAge();
                //Console.WriteLine($"new chef, age:{newChef.age}, dob.year:{newChef.dob.Year}, dob.month:{newChef.dob.Month}, dob.day:{newChef.dob.Day}, Today.Year: {DateTime.Now.Year}");
                if(newChef.GetAge() < 18)
                {
                    ModelState.AddModelError("dob","Chefs must be atleast 18 years old");
                    return View("AddChef");
                }
                _context.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddChef");
            }
        }

        [HttpGet("new_dish")]
        public IActionResult NewDish()
        {
            GetChefs();
            return View("AddDish");
        }

        [HttpPost("add_dish")]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                newDish.chef = _context.Chefs.FirstOrDefault(c => c.chefId == newDish.chefId);
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                GetChefs();
                return View("AddDish");
            }
        }

        private void GetChefs()
        {
            ViewBag.AllChefs = _context.Chefs;
        }

        private void GetChefsDishes()
        {
            ViewBag.AllChefs = _context.Chefs.Include(c => c.dishes).ToList();
        }

        private void GetDishes()
        {
            ViewBag.AllDishes = _context.Dishes.Include(d => d.chef);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
