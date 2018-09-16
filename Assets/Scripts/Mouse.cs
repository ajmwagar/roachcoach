using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Mouse : NetworkBehaviour 
{
	[SyncVar]
	public Color playerColor;
	[SyncVar]
	public string playerName;

	void Start () 
	{
		if(!isLocalPlayer)
		{
			GetComponent<MovementProto>().enabled = false;
			GetComponent<Basic3DRBmovement>().enabled = false;
			//GetComponent<climbzone>().enabled = false;
		}
        if (!isServer)
        {
            MouseItemGrabber[] mice = GetComponentsInChildren<MouseItemGrabber>();
            foreach(MouseItemGrabber mouse in mice)
            {
                mouse.enabled = false;
            }
        }
	}
	
	void Update () {
		
	}
}
