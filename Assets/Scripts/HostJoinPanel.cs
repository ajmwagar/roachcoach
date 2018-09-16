using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net;
using UnityEngine.Networking;

public class HostJoinPanel : MonoBehaviour 
{
	[Header("References")]
	public Text errorMessageText;
	public Text connectingMessage;

	[Header("Chef References")]
	[SerializeField]
	private GameObject chefPanel;

	[SerializeField]
	private TMP_InputField chefNameInputField;

	[SerializeField]
	private Button HostBtn;

	[Header("Mouse References")]

	[SerializeField]
	public GameObject mousePanel;
	[SerializeField]
	private TMP_InputField mouseNameInputField;
	[SerializeField]
	private TMP_InputField ipAddressInputField;
	[SerializeField]
	private Button mouseColorBtn;

	[SerializeField]
	private Button JoinGameBt;


	private NetManager netManager;
	private PlayerColors playerColors;
	private MainMenu mainMenu;

	// Use this for initialization
	void Start () 
	{
		HostBtn.onClick.AddListener(HostGame);
		mouseColorBtn.onClick.AddListener(ColorBtnHandler);
		JoinGameBt.onClick.AddListener(JoinGame);

		mainMenu = GetComponentInParent<MainMenu>();

		mainMenu.OnPlayerSelected += PlayerWasSelected;

		SetPlayerColor();
	}

	void PlayerWasSelected()
	{
		if(GameManager.playerType == PlayerType.Chef)
		{
			chefPanel.SetActive(true);
			mousePanel.SetActive(false);
		}
		else
		{
			chefPanel.SetActive(false);
			mousePanel.SetActive(true);
		}
	}
	private void HostGame()
	{
		errorMessageText.text = "";
		connectingMessage.text = "Creating game...";

		if(netManager == null)
		{
			netManager = GameObject.FindObjectOfType<NetManager>();
		}

		GameManager.playerName = chefNameInputField.text;
		if(string.IsNullOrEmpty(GameManager.playerName))
		{
			errorMessageText.text = "please enter a player name";
			connectingMessage.text = "";
			return;
		}

		StartCoroutine(WaitForHostStatus());
		netManager.StartHost();
	}

	private void ColorBtnHandler()
	{
		if(playerColors == null)
		{
			playerColors = GameObject.FindObjectOfType<PlayerColors>();
		}

		playerColors.colorIndex ++;

		if(playerColors.colorIndex >= playerColors.availableColors.Length)
		{
			playerColors.colorIndex = 0;
		}

		SetPlayerColor();
	}

	private void SetPlayerColor()
	{
		if(playerColors == null)
		{
			playerColors = GameObject.FindObjectOfType<PlayerColors>();
		}
		
		GameManager.playerColor =  playerColors.availableColors[playerColors.colorIndex];
		var colors = mouseColorBtn.colors;
		
		colors.normalColor = GameManager.playerColor;
		colors.highlightedColor = GameManager.playerColor;
		colors.pressedColor = playerColors.GetNextColor();

		mouseColorBtn.colors = colors;
	}

	private void JoinGame()
	{
		errorMessageText.text = "";
		if(netManager == null)
		{
			netManager = GameObject.FindObjectOfType<NetManager>();
		}

		GameManager.playerName = mouseNameInputField.text;
		if(string.IsNullOrEmpty(GameManager.playerName))
		{
			errorMessageText.text = "please enter a player name";
			return;
		}

		string ipAddress = ipAddressInputField.text;
		IPAddress adress = null;
		if(IPAddress.TryParse(ipAddress, out adress) == false)
		{
			errorMessageText.text = "IP is not valid";
			return;
		}


		StartCoroutine(WaitForClientConnectStatus());
		netManager.networkAddress = ipAddressInputField.text;
		netManager.StartClient();
	}

	
	IEnumerator WaitForHostStatus()
	{
		yield return new WaitForEndOfFrame();

		while(netManager.IsInvoking("StartHost"))
		{
			Debug.Log("Connecting...");
			yield return new WaitForEndOfFrame();
		}

		if(NetworkServer.active)
		{
			connectingMessage.text =  "connected!";
			errorMessageText.text = "";
		}
		else 
		{
			errorMessageText.text = "Failed to host game... :(";
			connectingMessage.text = "";
		}
	}

	IEnumerator WaitForClientConnectStatus()
	{
		yield return new WaitForEndOfFrame();

		while(netManager.IsInvoking("StartClient"))
		{
			Debug.Log("Connecting...");
			yield return new WaitForEndOfFrame();
		}

		if(NetworkServer.active)
		{
			connectingMessage.text =  "connected!";
			errorMessageText.text = "";
		}
		else 
		{
			errorMessageText.text = "Failed to connect to host... :(";
			connectingMessage.text = "";
		}
	}
}
