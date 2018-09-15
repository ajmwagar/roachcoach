using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MainMenu : MonoBehaviour 
{

	[SerializeField]
	private Button SetChefBtn;

	[SerializeField]
	private Button SetMouseBtn;

	[SerializeField]
	private GameObject hud;

	private 
	void Start ()
	{
		SetChefBtn.onClick.AddListener(SetPlayerAsChef);
		SetMouseBtn.onClick.AddListener(SetPlayerAsMouse);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			SetPlayerAsChef();
		}

		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			SetPlayerAsMouse();
		}
	}
	
	private void SetPlayerAsChef()
	{
		GameManager.playerType = PlayerType.Chef;

		SetChefBtn.interactable = false;
		SetMouseBtn.interactable = true;

		hud.SetActive(true);

	}

	private void SetPlayerAsMouse()
	{
		GameManager.playerType = PlayerType.Mouse;

		SetChefBtn.interactable = true;
		SetMouseBtn.interactable = false;

		hud.SetActive(true);
	}
}
