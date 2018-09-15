using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
        var mouse = other.gameObject.GetComponent<Mouse>();
		var chef = other.gameObject.GetComponent<Chef>();

		if (chef == null && mouse == null)
		   return; 

        if(mouse != null)
		{
			Debug.Log("mouse picked up item");
		}
        else
		{
           Debug.Log("chef picked up item");
		}

		gameObject.transform.SetParent(other.gameObject.transform);
		gameObject.transform.localPosition = new Vector3(0,1,-2);
	}
}
