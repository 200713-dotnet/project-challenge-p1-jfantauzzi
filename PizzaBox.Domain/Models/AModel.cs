namespace PizzaStore.Domain.Models
{
  public abstract class AModel
  {
    public int Id { get; set; }

    public string Option { get; set; } // also name

    public override string ToString()
    {
      return Option;
    }
    
  }
}