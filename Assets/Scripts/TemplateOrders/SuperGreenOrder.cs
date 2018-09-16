using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.TemplateOrders
{
  class SuperGreenOrder : Order
  {
    public SuperGreenOrder()
    {
      ingredients = new List<Ingredient>();
      ingredients.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ingredients.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ingredients.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ingredients.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ingredients.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ingredients.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ingredients.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      bread = new Ingredient(Ingredient.ITypes.WHITEBREAD);
    }

  }
}
