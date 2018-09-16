using Assets.Scripts.TemplateOrders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System;
public class OrderHandler : MonoBehaviour
{

    public AudioClip goodSound;
    public AudioClip badSound;
    public AudioClip incomingOrder;

    // Number of orders to hold in queue
    public const int ORDER_NUM = 20;

    // Current and final orders
    public Order final;
    public TwitchIRC twithComm;

    // Queue for handling orders
    public Queue<Order> orders = new Queue<Order>();

    public event Action<bool> OnOrderCompleted = delegate { };

    public OrderNotification orderNotification;

    DeliveryArea deliveryArea;

    // Use this for initialization
    void Start()
    {

        if (final == null)
        {
            gotoNextOrder();
        }

        deliveryArea = GameObject.FindObjectOfType<DeliveryArea>();
        deliveryArea.OnPlatePickUp += ValidateOrder;

    }

    // Update is called once per frame
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

    void Update()
    {

        if (final == null && orders != null && orders.Count > 0)
        {
            //final = orders.Dequeue();
        }
    }

    public void ValidateOrder(Plate plate)
    {
        Order current = new Order();
        AudioSource aSource = gameObject.GetComponent<AudioSource>();

        while (plate.items.Count > 0)
        {
            var ingredient = new Ingredient();
            ingredient.itype = plate.items.Pop().type;
            current.addIngredient(ingredient);
        }

        OnOrderCompleted.Invoke(final.IsSame(current));
        if (final.IsSame(current))
        {
            //Play Good Sound
            aSource.PlayOneShot(goodSound);
            gotoNextOrder();
        }
        else
        {
            //PLay Bad Sounf
            aSource.PlayOneShot(badSound);
        }
        plate.reset();
    }

    public void gotoNextOrder()
    {
        if (orders != null && orders.Count > 0)
        {
            final = orders.Dequeue();
            orderNotification.SetOrderNotification(final);
        }
    }

    public void handleStreamText(string message, string user)
    {
        Boolean customOrder = false;
        Order order = OrderFactory.Create(message);
        if (order == null)
        {
            order = Order.convertStringToOrder(message);
            order.setLabel("Custom Order").setUser(user);
            customOrder = true;
        }
        else
        {
            order = Order.convertStringToOrder(message, order);
        }
        if (validateOrder(order))
        {
            if (customOrder)
            {
                twithComm.SendMsg(string.Format("Sure {0}, I can make a sandwich that has {1}", order.user, order.ToPrettyString()));
            }
            else
            {
                twithComm.SendMsg(string.Format("You got it {0}, making that {1}", order.user, order.label));
            }
            orders.Enqueue(order);
            Debug.Log(order.ToString());
        }
        else
        {
            //Courtesy Message for bad ingredients
            twithComm.SendMsg(string.Format("Sorry {0}, thats not a real sandwich. Select a sandwich from our menu. To see it type: \"Hey Roach, whats on the menu?\" Or build your own by naming off the ingredients you want. To see our ingredients type \"Hey Roach, what ingredients do you have?\" .", user));
        }


    }

    public static bool validateOrder(Order order)
    {
        if (order == null)
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
        sb.Append("Menu Options:|");
        foreach (Order order in orders)
        {
            sb.AppendFormat("{0} - {1}|", order.label, order.ToPrettyString());

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