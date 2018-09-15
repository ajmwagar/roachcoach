using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour {
  public List<Ingredient> ings;

  public Order(bool random){
    if (random){
      // TODO Implement
    }
  }

  public Order(){
    ings = new List<Ingredient>();
  }
}
