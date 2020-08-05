using System;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class OrderModel : AModel
  {
    public List<PizzaModel> Pizzas { get; set; }
    public DateTime DateOrdered { get; set; }
    public double Total { get; set; }

    /* public void AddPizzaToOrder(List<ToppingModel> toppings, CrustModel crust, SizeModel size, string name)
    {
    
    } */

    public OrderModel()
    {
      Pizzas = new List<PizzaModel>() {};
      DateOrdered = DateTime.Now;
    }

  }
}