using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Mouse : NetworkBehaviour {

	// Use this for initialization
	void Start () 
	{
		if(!isLocalPlayer)
		{
			GetComponent<MovementProto>().enabled = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
