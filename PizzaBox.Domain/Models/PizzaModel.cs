using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class PizzaModel : AModel
  {
    public CrustModel Crust { get; set; }
    public SizeModel Size { get; set; }
    public List<ToppingModel> Toppings { get; set; }

    public double Price { get; set; }

    public PizzaModel()
    {
      
    }
  }
}
