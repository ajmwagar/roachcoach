using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinGamePanel : MonoBehaviour {

	[SerializeField]
	private MainMenu mainMenu;

	[SerializeField]
	private Text Info;

	void Start () {
		mainMenu.OnPlayerSelected += SetInstructions;
	}
	
	void Update () {
		
	}

	void SetInstructions() {

    	if (GameManager.playerType == PlayerType.Chef) {
		
			Info.text = "Chef";

		} else {

			Info.text = "Mouse";
		}
	}
}