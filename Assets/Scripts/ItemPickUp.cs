using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ItemPickUp : NetworkBehaviour 
{

	private new Rigidbody rigidbody;
	private void Start()
	{
		DisableClientScripts();

		rigidbody = GetComponent<Rigidbody>();
	}

	private void DisableClientScripts()
	{
		if(isServer == false)
		{
			var collider = GetComponent<SphereCollider>();

			if(collider == null)
			{
				Debug.LogWarning("No collider found on item:+ " + gameObject.name);
				return;
			}

			//collider.enabled = false;
		}
	}

	//void OnTriggerEnter(Collider other)
	void OnCollisionEnter(Collision other)
	{
		if(isServer == false)
			return;
			
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

		rigidbody.isKinematic = true;
	}
}
