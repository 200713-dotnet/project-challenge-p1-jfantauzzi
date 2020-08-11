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

    //get all pizzas
    [HttpGet()]
    public IActionResult Get()
    {
      ViewBag.PizzaList = _db.Pizzas.ToList();
      
      return View("Home", _db.Pizzas.ToList());
    }

    /* [HttpGet()]
    public IActionResult */

    //get specific pizza
    [HttpGet("{id}")]
    public IActionResult Edit(int id)
    {
      //how do i input id? another action calls this one
      return View("Edit", _db.Pizzas.SingleOrDefault(p => p.PizzaId == id));
      //return _db.Pizzas.SingleOrDefault(p => p.PizzaId == id);
    }

    
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

  /* [HttpPost]
  public IActionResult DeletePizza()
  {

  } */


  }

}