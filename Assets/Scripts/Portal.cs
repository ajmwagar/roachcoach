using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public Transform exit;
    public GameObject pointer;
    
    // Use this for initialization
	void Start () {
        pointer.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    //void OnCollisionEnter(Collision other)
    {

        GameObject player = other.gameObject;
        var mouse = player.GetComponent<Mouse>();
        var mouseStatus = player.GetComponent<MouseTeleport>();

        if (mouse && mouseStatus && !mouseStatus.isTeleporting)
        {
            mouseStatus.isTeleporting = true;
            player.transform.position = exit.position;
            player.transform.rotation = exit.rotation;
        }

    }
    void OnTriggerExit(Collider other)
    //void OnCollisionEnter(Collision other)
    {

        Debug.Log("Trigger Exit");

        GameObject player = other.gameObject;
        var mouse = player.GetComponent<Mouse>();
        var mouseStatus = player.GetComponent<MouseTeleport>();

        if (mouse && mouseStatus && !mouseStatus.isTeleporting)
        {
            mouseStatus.isTeleporting = false;
        }

    }


}
