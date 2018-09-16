using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.TemplateOrders
{
  class RedCheesyOrder : Order
  {
    public RedCheesyOrder()
    {
      label = "Red N Cheesy";
      ingredients = new List<Ingredient>();
      ingredients.Add(new Ingredient(Ingredient.ITypes.TOMATO));
      ingredients.Add(new Ingredient(Ingredient.ITypes.CHEESE));
      ingredients.Add(new Ingredient(Ingredient.ITypes.CHEESE));
      bread = new Ingredient(Ingredient.ITypes.WHEATBREAD);
    }
  }
}
