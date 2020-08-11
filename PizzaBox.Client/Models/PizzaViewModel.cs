using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaStore.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repository;

namespace PizzaBox.Client.Models
{
  public class PizzaViewModel
  {
    // out
    public List<CrustModel> Crusts { get; set; }
    public List<SizeModel> Sizes { get; set; }
    public List<ToppingModel> Toppings { get; set; }
    public List<CheckBoxTopping> Toppings2 { get; set; }

    // in
    [Required(ErrorMessage = "Select a crust!")]
    public string SelectedCrust { get; set; }
    [Required(ErrorMessage = "Select a size!")]
    public string SelectedSize { get; set; }

    
    //public List<string> SelectedToppings { get; set; }

    [MinLength(2, ErrorMessage = "You need a minimum of 2 toppings!")]
    [MaxLength(5, ErrorMessage = "You can't have more than 5 toppings!")]
    public List<string> SelectedToppings2 { get; set; }

    public PizzaViewModel()
    {
      var db = new Repository();
      Crusts = db.ReadCrusts();
      Sizes = db.ReadSizes();
      Toppings = db.ReadToppings();
      Toppings2 = new List<CheckBoxTopping>(); // { new CheckBoxTopping() {Text = "pepperoni ", IsSelected = false} };
      foreach (var t in Toppings)
      {
        Toppings2.Add(new CheckBoxTopping() { Id = t.Id, Option = t.Option, Text = t.Option, IsSelected = false });
      }
    }

    public class CheckBoxTopping : ToppingModel
    {
      public string Text { get; set; }
      public bool IsSelected { get; set; }
    }


  }
}