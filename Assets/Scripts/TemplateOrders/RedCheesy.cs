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
      ings = new List<Ingredient>();
      ings.Add(new Ingredient(Ingredient.ITypes.TOMATO));
      ings.Add(new Ingredient(Ingredient.ITypes.CHEESE));
      ings.Add(new Ingredient(Ingredient.ITypes.CHEESE));
      bread = new Ingredient(Ingredient.ITypes.WHEATBREAD);
    }
  }
}
