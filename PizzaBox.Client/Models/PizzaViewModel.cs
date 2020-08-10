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
    public CrustModel Crust { get; set; }
    [Required(ErrorMessage = "Select a size!")]
    public SizeModel Size { get; set; }

    //get a message telling user they're out of range
    public List<string> SelectedToppings { get; set; }

    [MinLength(2)]
    [MaxLength(5)]
    public List<string> SelectedToppings2 { get; set; }

    public PizzaViewModel()
    {
      var db = new Repository();
      //Crusts = new List<CrustModel>() { new CrustModel() { Option = "normal" } }; //repogivemecrusts()
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