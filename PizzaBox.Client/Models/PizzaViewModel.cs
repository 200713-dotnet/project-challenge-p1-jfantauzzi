using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaStore.Domain.Models;

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

    [MinLength(2), MaxLength(5)] //get a message telling user they're out of range
    public List<string> SelectedToppings { get; set; }
    public List<string> SelectedToppings2 { get; set; }

    public PizzaViewModel()
    {
      Crusts = new List<CrustModel>() { new CrustModel() { Option = "normal" } }; //repogivemecrusts()
      Sizes = new List<SizeModel>() { new SizeModel() { Option = "medium" } }; //repogivemesizes()
      Toppings = new List<ToppingModel>() { new ToppingModel() { Option = "pepperoni" } };
    }

    public class CheckBoxTopping : ToppingModel
    {
      public string Text { get; set; }
      public bool IsSelected { get; set; }
    }

  }
}