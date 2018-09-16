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
      label = "Super Green";
      ings = new List<Ingredient>();
      ings.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ings.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ings.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ings.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ings.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ings.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      ings.Add(new Ingredient(Ingredient.ITypes.LETTUCE));
      bread = new Ingredient(Ingredient.ITypes.WHITEBREAD);
    }

  }
}
