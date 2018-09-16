using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

  public class Ingredient
  {
    public enum ITypes
    {
      LETTUCE, TOMATO, CHEESE, HAM, WHEATBREAD, WHITEBREAD
    }

    public ITypes itype;

    public Ingredient(bool random)
    {
      if (random)
      {
        System.Random ran = new System.Random();
        int d = ran.Next(0, 7);
        itype = (ITypes)d;
      }
    }

    public Ingredient(ITypes itype)
    {
      this.itype = itype;
    }

    public Ingredient()
    {
      this.itype = ITypes.LETTUCE;
    }

    public static bool convertToIngredient(string ingredient, out Ingredient ingr)
    {
      ITypes tempType = Ingredient.ITypes.CHEESE;
      string normString = ingredient.ToLower();
      bool found = false;

      //TODO change to switch statement
      if (normString == "lettuce")
      {
        tempType = ITypes.LETTUCE;
        found = true;
      }
      else if (normString == "cheese")
      {
        tempType = ITypes.CHEESE;
        found = true;
      }
      else if (normString.Contains("tomato"))
      {
        tempType = ITypes.TOMATO;
        found = true;
      }
      else if (normString == "ham")
      {
        tempType = ITypes.HAM;
        found = true;
      }
      else if (new Regex(".*white.*").IsMatch(normString))
      {
        tempType = ITypes.WHITEBREAD;
        found = true;
      }
      else if (new Regex(".*wheat.*").IsMatch(normString))
      {
        tempType = ITypes.WHEATBREAD;
        found = true;
      }
      ingr = new Ingredient(tempType);
      return found;
    }

    public override string ToString()
    {
        return this.itype.ToString();
    }
  }