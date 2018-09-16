using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour {

        public Stack<IngredientItem> items = new Stack<IngredientItem>();

        void OnTriggerEnter(Collider col){
          IngredientItem item = col.GetComponent<IngredientItem>();
          if (item == null){
            return;
          }
          else {
            items.Push(item);
            Debug.Log("Added IngredientItem");
          }
          
        }

        void OnTriggerExit(Collider col){
          if (col.gameObject.GetComponent<IngredientItem>() != null){
            Debug.Log("Pop");
            items.Pop();
          }
        }
          

        void update(){
          if (items != null){
            

          }
        }
}
