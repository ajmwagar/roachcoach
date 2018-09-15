using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderHandler : MonoBehaviour {
  // Number of orders to hold in queue
  public const int ORDER_NUM = 20;

  // Current and final orders
  public Order current;
  public Order final;

  // Queue for handling orders
  public Queue<Order> orders = new Queue<Order>();

  // Use this for initialization
  void Start () {
    for (int i = 0; i < ORDER_NUM; i++){
      newOrder();
    }

    current = new Order();
    final = orders.Dequeue();
    foreach (Order o in orders){
      Recipe(o);
    }

  }

  // Update is called once per frame
  void Update () {
    // TODO Replace with realy
    bool done = OrderCheck(new Order(), new Order());

    // Goto next order
    if (done){
      current = new Order();
      final = orders.Dequeue();
      Recipe(current);
    }

  }

  bool OrderCheck(Order final, Order current){
    final = sort(final);
    current = sort(current);

    // TODO Implement
    /* final.ings.ITypes; */
    return false;
  }

  Order sort(Order sortme){
    //  List<Ingredient> SortedList = sortme.ings.OrderBy(o=>int(o)).ToList();
    //  sortme.ings = SortedList;

    return sortme;
  }

  // Creates a random order and adds to queue
  void newOrder(){
    orders.Enqueue(new Order(true));
  }

  // Debug.Log's the order
  void Recipe(Order final){
    Debug.Log("Order Up:");
    foreach(Ingredient ing in final.ings){
      Debug.Log("Ingredient: " + ing.current.ToString());
    }
  }

}
