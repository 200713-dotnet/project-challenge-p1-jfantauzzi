using System.Collections.Generic;
using PizzaStore.Domain.Factories;

namespace PizzaStore.Domain.Models
{
  public class StoreModel : AModel
  {

    public List<OrderModel> Orders { get; set; }

    // Singleton private IFactory _factory;
    /* private readonly StoreModel _store;

    private StoreModel( IFactory factory)
    {
      //_factory = factory;
    }


    public StoreModel Instance(IFactory factory)
    {
      if (_store == null || _store._factory.GetType().Option != factory.GetType().Option)
      {
        _store = new StoreModel(factory);
      }
    }

    public CreateOrder()
    {
      AModel pm = _factory.Create();
    } 
    */

  }
}