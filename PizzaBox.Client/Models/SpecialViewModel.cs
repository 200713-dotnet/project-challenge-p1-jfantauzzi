using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaStore.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repository;

namespace PizzaBox.Client.Models
{
  public class SpecialViewModel
  {
    //out
    public List<CrustModel> Crusts { get; set; }
    public List<SizeModel> Sizes { get; set; }
    public List<ToppingModel> Toppings { get; set; }
    public List<string> Specials { get; set; }


    //in
    
    public string SelectedCrust { get; set; }
    //[Required(ErrorMessage = "Select a size!")]
    public string SelectedSize { get; set; }
    //[Required(ErrorMessage = "Pick a Special Pizza Type!")]
    public string SelectedSpecial { get; set; }
    public List<string> SelectedToppings { get; set; }

    public SpecialViewModel()
    {
      Specials = new List<string>() {  "The Regular", "The Deep Little", "The Pizza Timer" };
      var db = new Repository();
      Crusts = db.ReadCrusts();
      Sizes = db.ReadSizes();
      Toppings = db.ReadToppings();
    }


  }

}