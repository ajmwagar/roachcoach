using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.TemplateOrders
{
  public enum orderType { HLT, RedNCheesy, SuperGreen, Vegan}
  public static class OrderFactory
  {

    public static List<Order> getAllPossibleOrders()
    {
      List<Order> orders = new List<Order>();
      foreach(orderType  ot in Enum.GetValues(typeof(orderType)))
      {
        orders.Add(Create(ot));
      }
      return orders;
    }

    public static Order Create(orderType type )
    {
      switch (type)
      {
        case orderType.HLT:
          return new HLTOrder();
        case orderType.RedNCheesy:
          return new RedCheesyOrder();
        case orderType.SuperGreen:
          return new SuperGreenOrder();
        case orderType.Vegan:
          return new VeganOrder();
        default:
          return new HLTOrder();
      }
    }
    
  }
}
