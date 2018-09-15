using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order {
  public const int MAX_INGS = 8;
  public const int MIN_INGS = 3;


  public List<Ingredient> ings;

  public Order(bool random){
    if (random){
      ings = new List<Ingredient>();

      for (int i = 0; i < MAX_INGS; i++){
        ings.Add(new Ingredient(true));
      }

    }
  }

  public Order(){
    ings = new List<Ingredient>();
  }
}
