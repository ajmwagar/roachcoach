using Assets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour {

  public Order order;
  public TextMeshPro orderDescription;
  public void setOrder(Order order)
  {
    orderDescription.text = order.description;
  }

  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
