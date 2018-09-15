using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType { Chef, Mouse };

public class GameManager : MonoBehaviour
{
	public static string playerName;
	public static PlayerType playerType;
	public static Color playerColor;
}
