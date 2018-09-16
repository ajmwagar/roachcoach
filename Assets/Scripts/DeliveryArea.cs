using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeliveryArea : MonoBehaviour 
{
	public float pickupDeliveryTimeInSecs = 3;

	public event Action OnOrderAdded = delegate { };
	public event Action<Plate> OnPlatePickUp = delegate { }; 

	private Dictionary<Plate, DateTime> deliveryArea;

	private void Start()
	{
		deliveryArea = new Dictionary<Plate, DateTime>();
	}

	private void Update()
	{
		if(deliveryArea.Keys.Count > 0)
		{
			foreach(var key in deliveryArea.Keys)
			{
				if(deliveryArea[key] > System.DateTime.UtcNow)
				{
					OnPlatePickUp.Invoke(key);
					deliveryArea.Remove(key);

				}
			}
		}
	}

    void OnTriggerEnter(Collider col)
	{
		var plate = col.gameObject.GetComponent<Plate>();

		if(plate == null)
			return;
		
		var pickupTime = System.DateTime.UtcNow.AddSeconds(pickupDeliveryTimeInSecs);

		if(deliveryArea.ContainsKey(plate) == false)
		{
			deliveryArea.Add(plate, pickupTime);
		}
    }

    void OnTriggerExit(Collider col)
	{
		var plate = col.gameObject.GetComponent<Plate>();

		if(plate == null)
			return;
		
		var pickupTime = System.DateTime.UtcNow.AddSeconds(pickupDeliveryTimeInSecs);

		if(deliveryArea.ContainsKey(plate) == false)
		{
			deliveryArea.Remove(plate);
		}
    }
}