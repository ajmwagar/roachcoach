using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbzone : MonoBehaviour {


	public GameObject player;
	Basic3DRBmovement mover;

	void Start(){
		mover = player.GetComponent<Basic3DRBmovement> ();
	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject == player) {
			mover.canClimb = true;

		}
	}


	void OnTriggerExit(Collider col){
		if (col.gameObject == player) {
			mover.canClimb = false;
		}
	}


}
