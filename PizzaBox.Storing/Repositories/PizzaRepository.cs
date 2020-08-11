using System.Collections.Generic;
using PizzaStore.Domain.Factories;
using System.Linq;
using domain = PizzaStore.Domain.Models;

namespace PizzaBox.Storing.Repository
{
  public class Repository
  {
    private PizzaStoreDbContext _db = new PizzaStoreDbContext();

    /* public void CreatePizza(domain.PizzaModel pizza)
    {
      var newPizza = new Pizza();
      var topping = new PizzaTopping();

      newPizza.Crust = new Crust() { Option = pizza.Crust.Option };
      newPizza.Size = new Size() { Option = pizza.Crust.Option };
      newPizza.Option = pizza.Option;

      _db.Pizzas.Add(newPizza);
      _db.PizzaTopping.Add(topping);
      _db.SaveChanges();

    }
 */

    public int GetLasestPizzaId()
    {
      var piz = new Pizza();
      var pizlist = new List<Pizza>();
      pizlist = Read();
      piz = pizlist.Last();
      return piz.PizzaId;
    }

    public void CreatePizza(int CrId, int SiId, string name)
    {
      var newPizza = new Pizza();

      newPizza.CrustId = CrId;
      newPizza.SizeId = SiId;
      newPizza.Option = name;

      _db.Pizzas.Add(newPizza);
      _db.SaveChanges();
    }

    public void CreatePizzaTopping(int PizKey, int topKey)
    {
      var topping = new PizzaTopping();

      topping.PizzaId = PizKey;
      topping.ToppingId = topKey;

      _db.PizzaTopping.Add(topping);
      _db.SaveChanges();

    }
    public IEnumerable<domain.PizzaModel> ReadAll() //or list
    {
      var domainPizzaList = new List<domain.PizzaModel>();

      foreach (var item in _db.Pizzas.ToList())
      {
        domainPizzaList.Add(new domain.PizzaModel()
        {
          Crust = new domain.CrustModel() { Option = item.Crust.Option },
          Size = new domain.SizeModel() { Option = item.Size.Option },
          Toppings = new List<domain.ToppingModel>() { },
        });

      };
      //return _db.Pizza.ToList(); //select * from pizza
      return domainPizzaList;
    }

    public List<Pizza> Read() //or list
    {
      var PizzaList = new List<Pizza>();

      foreach (var item in _db.Pizzas.ToList())
      {
        PizzaList.Add(new Pizza()
        {
          PizzaId = item.PizzaId,
          SizeId = item.SizeId,
          CrustId = item.CrustId,
          Option = item.Option
        });

      };
      //return _db.Pizza.ToList(); //select * from pizza
      return PizzaList;
    }

    public List<domain.CrustModel> ReadCrusts()
    {
      var domainCrustList = new List<domain.CrustModel>();

      foreach (var crust in _db.Crusts.ToList())
      {
        domainCrustList.Add(new domain.CrustModel() { Option = crust.Option });
      }
      return domainCrustList;
    }

    public List<domain.SizeModel> ReadSizes()
    {
      var domainSizeList = new List<domain.SizeModel>();

      foreach (var size in _db.Sizes.ToList())
      {
        domainSizeList.Add(new domain.SizeModel() { Option = size.Option });
      }
      return domainSizeList;
    }

    public List<domain.ToppingModel> ReadToppings()
    {
      var domainToppingList = new List<domain.ToppingModel>();

      foreach (var topping in _db.Toppings.ToList())
      {
        domainToppingList.Add(new domain.ToppingModel() { Option = topping.Option });
      }
      return domainToppingList;
    }

    public void Update()
    {

    }

    public void DeleteLast()
    {
      /* var id = GetLasestPizzaId();
      _db.
      _db.SaveChanges(); */
    }

  }
}