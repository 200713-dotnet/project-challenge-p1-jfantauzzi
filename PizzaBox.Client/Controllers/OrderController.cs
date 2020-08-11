using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repository;
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

    public IActionResult Preset()
    {
      return View("Preset", new SpecialViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult PlaceOrder(PizzaViewModel pizzaVM) //model binding
    {
      if (ModelState.IsValid)
      {
        int cr = 1;
        int si = 1;
        List<int> top = new List<int>();

        ///convert selections to id's
        switch (pizzaVM.SelectedCrust)
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

        switch (pizzaVM.SelectedSize) 
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
        ///

        //adding pizza and pizzatopping to repo
        var db = new Repository();
        db.CreatePizza(cr, si, "Custom Pizza");
        int key = db.GetLasestPizzaId();
        foreach (var i in top)
        {
          db.CreatePizzaTopping(key, i);
        }

        return Redirect("/pizza/get");
        //return Redirect("/user/index"); // http 300-series status
      }

      return View("Order", pizzaVM);
    }

    [HttpPost]
    public IActionResult PresetOrder(SpecialViewModel specialVM) //model binding
    {
        System.Console.WriteLine(ModelState.IsValid);
        int si = 1;
        int cr = 1;
        string spec = specialVM.SelectedSpecial;
        List<int> top = new List<int>();

        switch (specialVM.SelectedSize) 
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

        //determine crust, toppings based of special
        if (spec == "The Regular")
        {
          cr = 1;
          top.Add(1);
          top.Add(2);
        }
        else if(spec == "The Deep Little")
        {
          cr = 3;
          top.Add(1);
          top.Add(4);
          top.Add(6);
        }
        else if(spec == "The Pizza Timer")
        {
          cr = 2;
          top.Add(1);
          top.Add(3);
          top.Add(5);
          top.Add(6);
        }
        else
        {
          return View("Order", specialVM);
        }
        ///  

        //adding pizza and pizzatopping to repo
        var db = new Repository();
        db.CreatePizza(cr, si, spec);
        int key = db.GetLasestPizzaId();
        foreach (var i in top)
        {
          db.CreatePizzaTopping(key, i);
        }

        return Redirect("/pizza/get");
        //return Redirect("/user/index"); // http 300-series status

    }

    [HttpDelete]
    public IActionResult Delete()
    {
      var db = new Repository();
      db.DeleteLast();
      return Redirect("/pizza/get");
    }



  }
}