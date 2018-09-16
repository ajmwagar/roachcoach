using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

  public class Order
  {
    public const int MAX_INGREDIENTS = 6;
    public const int MIN_INGREDIENTS = 3;


    public List<Ingredient> ingredients;
    public Ingredient bread;
    public String label = "";
    public String user = "";

    public static Order convertStringToOrder(String orderString)
    {
      return convertStringToOrder(orderString, new Order()); 
    }


    public static Order convertStringToOrder(String orderString, Order baseOrder)
    {
      Ingredient ingr;
      String[] words = orderString.Split(' ', ',');
      Boolean extra = false;
      Boolean subtract = false;
      foreach (string word in words)
      {
        if (Ingredient.convertToIngredient(word, out ingr))
        {
          //If its bread handle bread
          if (isBread(ingr))
          {
            baseOrder.bread = ingr; 
          }
          else //else  its a topping
          { 
          if (subtract)
          {
            baseOrder.removeIngredient(ingr);
          }
          else
          {
            baseOrder.addIngredient(ingr);
            if (extra)
              baseOrder.addIngredient(ingr);
          }
        }
        }
        else
        {
          extra = false;
          subtract = false;
        }

        if (word.ToLower().Contains("extra"))
        {
          extra = true;
        }
        if (word.ToLower() == "no" || word.ToLower() == "without")
        {
          subtract = true;
        }
      }
      if (baseOrder.ingredients.Count > 0)
      {
        return baseOrder;
      }
      else
      {
        return null;
      }
    }
    public Order(bool random)
    {
      if (random)
      {
        ingredients = new List<Ingredient>();

        for (int i = 0; i < MAX_INGREDIENTS; i++)
        {
          ingredients.Add(new Ingredient(true));
        }

      }
    }

    public static Boolean isBread(Ingredient ingr)
    {
      return (ingr.itype == Ingredient.ITypes.WHITEBREAD || ingr.itype == Ingredient.ITypes.WHEATBREAD);
    }
     public Order()
     {
       ingredients = new List<Ingredient>();
     }

        public void addIngredient(Ingredient ingr)
        {
          ingredients.Add(ingr);
        }

        /// <summary>
        /// Removes all occurences of specified ingredient in the order
        /// </summary>
        /// <param name="ingr"></param>
        public void removeIngredient(Ingredient ingr)
        {
          ingredients.RemoveAll(x => x.itype == ingr.itype);
        }

        public Order setLabel(String label)
        {
          this.label = label;
          return this;
        }

        public Order setUser(String user)
        {
          this.user = user;
          return this;
        }

        public bool IsSame(Order other)
        {
          if(other == null)
          {
            return false;
          }
          
          if(this.ingredients.Count != other.ingredients.Count)
          {
            return false;
          }

          other.ingredients.Sort();
          this.ingredients.Sort();

          for(int i = 0; i < other.ingredients.Count; i++){
            if (other.ingredients[i].itype != this.ingredients[i].itype){
              return false;
            }
          }

          return true;
        }

    public override string ToString()
    {
      String ingredients = "";
      foreach(Ingredient ingr in this.ingredients)
      {
        ingredients += ingr.ToString() + " ";
      }
      return JsonUtility.ToJson(this) + bread + ingredients;
    }

    public String toPrettyString()
    {
      StringBuilder sb = new StringBuilder();
      Dictionary<Ingredient.ITypes, int> ingredients = new Dictionary<Ingredient.ITypes, int>();
      foreach (Ingredient ingr in this.ingredients)
      {
        if (!ingredients.ContainsKey(ingr.itype))
          ingredients.Add(ingr.itype, 0);

        ingredients[ingr.itype] += 1;
      }

      sb.AppendFormat("{0} w/ ", bread);
      foreach (Ingredient.ITypes type in Enum.GetValues(typeof(Ingredient.ITypes)))
      {
        if (ingredients.ContainsKey(type))
        { 
          sb.Append(ingredients[type]);
          sb.Append(" ");
          sb.Append(type.ToString());
          sb.Append(',');
        }
      }
      sb.Remove(sb.Length - 1, 1);

      return sb.ToString();
    }

    // public List<Ingredient> Sort(List<Ingredient> list){
    //   for(int i = 0; i < list.Count; i++){
    //     //if (list.Sort)
    //   }
    // }

  }