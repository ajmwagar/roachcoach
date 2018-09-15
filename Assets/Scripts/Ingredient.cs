using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient {
  // Add more
  public enum ITypes {
    LETTUCE, TOMATO, CHEESE, HAM, WHEATBREAD, WHITEBREAD
  }

  public ITypes current;

  // Return a random Ingredient
  public Ingredient(bool random){
    if (random){
      System.Random ran = new System.Random();
      int d = ran.Next(0,7);
      Debug.Log(d);
      current = (ITypes) d;
    }
  }
}
