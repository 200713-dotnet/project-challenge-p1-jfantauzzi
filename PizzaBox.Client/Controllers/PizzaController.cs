using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;
using PizzaStore.Domain.Models;

namespace PizzaBox.Client.Controllers
{
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

    //get specific pizza
    [HttpGet("{id}")]
    public PizzaModel Get(int id)
    {
      return _db.Pizzas.SingleOrDefault(p => p.Id == id);
    }

  }

}