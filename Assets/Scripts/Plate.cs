using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour {

        public Stack<IngredientItem> items = new Stack<IngredientItem>();
  private Vector3 startLocation = Vector3.zero;
  private Quaternion startRotation = Quaternion.identity;

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

        public void reset()
        {
          transform.position = startLocation;
          transform.rotation = startRotation;
          foreach(IngredientItem item in items){
            Destroy(item);
          }
    items = new Stack<IngredientItem>();
        }

        private void Start()
        {
          startLocation = transform.position;
          startRotation = transform.rotation = startRotation;
        }


  void update(){
          if (items != null){
            

          }
        }
}
