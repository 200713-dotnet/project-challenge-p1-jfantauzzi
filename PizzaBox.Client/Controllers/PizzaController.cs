using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;
using PizzaBox.Storing.Repository;
using PizzaStore.Domain.Models;

namespace PizzaBox.Client.Controllers
{
  //[Route("/[controller]/[action]")]
  public class PizzaController : Controller
  {
    private readonly PizzaStoreDbContext _db;

    public PizzaController(PizzaStoreDbContext dbContext)
    {
      _db = dbContext;
    }

    public IActionResult Edit()
    {
      ViewBag.PizzaList = _db.Pizzas.ToList();
      //how do i input id? another action calls this one
      return View( "Edit", _db.Pizzas.ToList() );
      //return _db.Pizzas.SingleOrDefault(p => p.PizzaId == id);
    }

    //get all pizzas
    [HttpGet()]
    public IActionResult Get()
    {
      ViewBag.PizzaList = _db.Pizzas.ToList();

      return View("Home", _db.Pizzas.ToList());
    }

    /* [HttpPost]
    public IActionResult PizzaToEdit(List<Pizza> _db.Pizzas.ToList())
    {

    } */

  
    //get specific pizza



    /* [HttpDelete()]
     public IActionResult Delete()
     {
       var db = new Repository();
       ViewBag.PizzaList = _db.Pizzas.ToList();
       if(ViewBag.PizzaList.rows.Any())
       {
         ViewBag.PizzaList.rows.Revomeat(ViewBag.PizzaList.rows.Count-1);
       }

       return View("/pizza/get", _db.Pizzas.ToList());
     } */



  }

}