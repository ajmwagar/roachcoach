using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinGamePanel : MonoBehaviour {

	[SerializeField]
	private MainMenu mainMenu;

	[SerializeField]
	private Text Info;

	void Awake () {
		mainMenu.OnPlayerSelected += SetInstructions;
	}
	
	void Update () {
		
	}

	void SetInstructions() {

    	if (GameManager.playerType == PlayerType.Chef) {
		
			Info.text = "Complete as many orders as you can and make sure the mice don't get your food!";

		} else {

			Info.text = "Steal the Chef's ingredients and escape through the hole in the wall to score points.\n" + 
			"WASD and you can climb walls once you get close to them.";
		}
	}
}