using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.TemplateOrders
{
  //Meat lettuce tomato sandwich on whitebread
  public class VeganOrder : Order
  {
    public VeganOrder()
    {
      label = "The Vegan";
      ingredients = new List<Ingredient>();
      ingredients.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ingredients.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ingredients.Add(new Ingredient(Ingredient.ITypes.TOMATO));
      ingredients.Add(new Ingredient(Ingredient.ITypes.TOMATO));
      bread = new Ingredient(Ingredient.ITypes.WHITEBREAD);
    }
  }
}
