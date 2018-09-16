using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbzone : MonoBehaviour {


	public GameObject player;
	private Basic3DRBmovement mover;
	private Mouse mouse;

	void Start()
	{
		mover = player.GetComponent<Basic3DRBmovement> ();
	}


	void OnTriggerEnter(Collider col)
	{
		mouse = col.gameObject.GetComponent<Mouse>();
		if (mouse != null) {
			mover.canClimb = true;

		}
	}


	void OnTriggerExit(Collider col)
	{
		mouse = col.gameObject.GetComponent<Mouse>();
		if (mouse != null) {
			mover.canClimb = false;
		}
	}
}
