using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColors : MonoBehaviour {

	public Color[] availableColors;
	public int colorIndex = 0;

	public Color GetNextColor()
	{
		int nextIndex = colorIndex + 1;

		if(nextIndex >= availableColors.Length)
		{
			nextIndex = 0;
		}

		return availableColors[nextIndex];
	}
}
