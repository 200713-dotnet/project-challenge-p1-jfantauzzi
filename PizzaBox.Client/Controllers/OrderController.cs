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
    public IActionResult PlaceOrder(PizzaViewModel pizzaVM) //model binding
    {
      System.Console.WriteLine(ModelState.IsValid);
      if (ModelState.IsValid)
      {
        int cr = 1;
        int si = 1;
        List<int> top = new List<int>();
        // var p = new Pizza(); // dependency injection
        switch (pizzaVM.Crust.Option)
        {
          case "normal":
            cr = 1;
            break;
          case "stuffed":
            cr = 2;
            break;
          case "deepdish":
            cr = 3;
            break;
          default:
            break;
        }

        switch (pizzaVM.Size.Option)
        {
          case "small":
            si = 1;
            break;
          case "medium":
            si = 2;
            break;
          case "large":
            si = 3;
            break;
          default:
            break;
        }

        foreach (var t in pizzaVM.SelectedToppings2)
        {
          switch (t)
          {
            case "cheese":
              top.Add(1);
              break;
            case "pepperoni":
              top.Add(2);
              break;
            case "peppers":
              top.Add(3);
              break;
            case "ham":
              top.Add(4);
              break;
            case "onions":
              top.Add(5);
              break;
            case "sausage":
              top.Add(6);
              break;
          }
        }

        using (var db = new PizzaStoreDbContext())
        {

          db.Pizzas.Add(new Pizza()
          {
            CrustId = cr,
            SizeId = si,
            Option = "Custom Pizza"
          });

          int key = db.Pizzas.Max(t => t.PizzaId);
          foreach (var i in top)
            db.PizzaTopping.Add(new PizzaTopping
            {
              PizzaId = key,
              ToppingId = i
            });

          //    add to order  ////
        }

        _db.SaveChanges();

        return View("/pizza/get");
        //return Redirect("/user/index"); // http 300-series status
      }

      return View("Order", pizzaVM);
    }
  }
}