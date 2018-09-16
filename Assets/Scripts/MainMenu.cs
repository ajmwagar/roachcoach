using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class MainMenu : MonoBehaviour 
{
	[SerializeField]
	private bool UseDefaultHUD = false;

	[SerializeField]
	private Button SetChefBtn;

	[SerializeField]
	private Button SetMouseBtn;

	[SerializeField]
	private GameObject JoinGamePanel;

	[SerializeField]
	private GameObject FirstMenuPanel;

	[SerializeField]
	private Button BackBtn;

	public event Action OnPlayerSelected = delegate{};

	[SerializeField]
	private GameObject hud;

	void Start ()
	{
		SetChefBtn.onClick.AddListener(SetPlayerAsChef);
		SetMouseBtn.onClick.AddListener(SetPlayerAsMouse);
		BackBtn.onClick.AddListener(BackHandler);

		FirstMenuPanel.SetActive(true);
		JoinGamePanel.SetActive(false);
	}

	void Update()
	{
		// if(Input.GetKeyDown(KeyCode.Alpha1))
		// {
		// 	SetPlayerAsChef();
		// }

		// if(Input.GetKeyDown(KeyCode.Alpha2))
		// {
		// 	SetPlayerAsMouse();
		// }
	}
	
	private void SetPlayerAsChef()
	{
		GameManager.playerType = PlayerType.Chef;


		//hud.SetActive(true);
		SetJoinGamePanel();
	}

	private void SetPlayerAsMouse()
	{
		GameManager.playerType = PlayerType.Mouse;

		//hud.SetActive(UseDefaultHUD);
		SetJoinGamePanel();

	}

	private void SetJoinGamePanel()
	{
		JoinGamePanel.SetActive(true);
		FirstMenuPanel.SetActive(false);

		OnPlayerSelected.Invoke();
	}

	private void BackHandler(){
	   JoinGamePanel.SetActive(false);
	   FirstMenuPanel.SetActive(true);
	}
}