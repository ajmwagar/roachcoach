using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Mouse : NetworkBehaviour {

	void Start () 
	{
		if(!isLocalPlayer)
		{
			GetComponent<MovementProto>().enabled = false;
			GetComponent<Basic3DRBmovement>().enabled = false;
			GetComponent<climbzone>().enabled = false;
		}	
	}
	
	void Update () {
		
	}
}
