using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;
using PizzaStore.Domain.Factories;

namespace PizzaStore.Client.Controllers
{
//[Route("/[controller]/[action]")]
  public class OrderController : Controller
  {
    private readonly PizzaStoreDbContext _db;

    public OrderController(PizzaStoreDbContext dbContext) // constructor dependency injection
    {
      _db = dbContext;
    }

    public IActionResult Start()
    {
      return View("Order", new PizzaViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post(PizzaViewModel pizzaViewModel) //model binding
    {
      if (ModelState.IsValid)
      {
        var p = new PizzaFactory(); // use dependency injection

        return Redirect("/user/index"); // http 300-series status
      }

      return View("Order", pizzaViewModel);
    }
  }
}