using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordermanager : MonoBehaviour {

	DeliveryArea deliveryArea;
	// Use this for initialization
	void Start () 
	{
		//deliveryArea = GameObject.FindGameObjectOfType<DeliveryArea>();
		//deliveryArea.OnPlatePickUp += CheckOrder;
	}
	

	private void CheckOrder(Plate plate)
	{
		Debug.Log("Received order");
	}
}
