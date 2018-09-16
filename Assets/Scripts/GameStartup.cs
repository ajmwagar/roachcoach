using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartup : MonoBehaviour {

    public GameObject[] chefStuff;
    public GameObject[] mouseStuff;
    
    // Use this for initialization
	void Start () {
		if(GameManager.playerType == PlayerType.Chef)
        {
            foreach(GameObject thing in chefStuff)
            {
                thing.SetActive(true);
            }

            foreach (GameObject thing in mouseStuff)
            {
                thing.SetActive(false);
            }

        }
        else if (GameManager.playerType == PlayerType.Mouse)
        {
            foreach (GameObject thing in chefStuff)
            {
                thing.SetActive(false);
            }

            foreach (GameObject thing in mouseStuff)
            {
                thing.SetActive(true);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
