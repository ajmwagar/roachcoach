using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HostJoinPanel : MonoBehaviour 
{
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

	// Use this for initialization
	void Start () 
	{
		HostBtn.onClick.AddListener(HostGame);
		mouseColorBtn.onClick.AddListener(ColorBtnHandler);
		JoinGameBt.onClick.AddListener(JoinGame);
		
	}


	private void HostGame()
	{

	}
	
	private void ColorBtnHandler()
	{

	}

	private void JoinGame()
	{

	}

}
