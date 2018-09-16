using Assets.Scripts.TemplateOrders;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System;
  public class OrderHandler : MonoBehaviour
  {
    // Number of orders to hold in queue
    public const int ORDER_NUM = 20;

    // Current and final orders
    public Order current;
    public Order final;
    public TwitchIRC twithComm;

    // Queue for handling orders
    public Queue<Order> orders = new Queue<Order>();

    public event Action<bool> OnOrderCompleted = delegate { };

    DeliveryArea deliveryArea;

    // Use this for initialization
    void Start()
    {
      for (int i = 0; i < ORDER_NUM; i++)
      {
        newOrder();
      }

      current = new Order();
      final = orders.Dequeue();
      foreach (Order o in orders)
      {
        Recipe(o);
      }

      deliveryArea = GameObject.FindObjectOfType<DeliveryArea>();
		  deliveryArea.OnPlatePickUp += PickUpFinishedOrder;

    }

    // // Update is called once per frame
    // void Update()
    // {
    //   // TODO Replace with realy
    //   bool done = final.IsSame(current); //OrderCheck(new Order(), new Order());

    //   // Goto next order
    //   if (done)
    //   {
    //     current = new Order();
    //     final = orders.Dequeue();
    //     Recipe(current);
    //   }

    // }

    public void PickUpFinishedOrder(Plate plate)
    {
        current = new Order();

        while(plate.items.Count > 0)
        {
          var ingredient = new Ingredient();
          ingredient.itype = plate.items.Pop().type;
          current.addIngredient(ingredient);
        }

        OnOrderCompleted.Invoke(final.IsSame(current));
    }

    public void handleStreamText(string message, string user)
    {
      Order order = Order.convertStringToOrder(message);
      if (validateOrder(order))
      {
        order.setLabel("Custom Order").setUser(user);
        orders.Enqueue(order);
        Debug.Log(order.ToString());
      }
      else
      {
        //Courtesy Message for bad ingredients
        twithComm.SendMsg(string.Format("Sorry {0}, thats not a real sandwich. We need a type of bread.", user));
      }


      }

      public static bool validateOrder(Order order)
    {
      if(order == null)
      {
        return false;
      }
      bool hasBread = (order.bread != null);
      return hasBread;
    }

    public static string whatsOnTheMenu()
    {
      StringBuilder sb = new StringBuilder();
      List<Order> orders = OrderFactory.getAllPossibleOrders();
      sb.Append("Menu Options:");
      foreach (Order order in orders) {
        sb.AppendFormat("*** {0} - {1} ***", order.label, order.toPrettyString());
       
      }

      return sb.ToString();
    }

    // Creates a random order and adds to queue
    void newOrder()
    {
      orders.Enqueue(new Order(true));
    }

    // Debug.Log's the order
    void Recipe(Order final)
    {
      Debug.Log("Order Up:");
      foreach (Ingredient ing in final.ingredients)
      {
        Debug.Log("Ingredient: " + ing.itype.ToString());
      }
    }
  }