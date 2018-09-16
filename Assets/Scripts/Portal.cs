using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public GameObject exit;
    public GameObject pointer;
    public bool inUse;
    
    // Use this for initialization
	void Start () {
        pointer.SetActive(false);
        bool inUse = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    //void OnCollisionEnter(Collision other)
    {

        Debug.Log("Trigger Enter");
        GameObject player = other.gameObject;
        var mouse = player.GetComponent<Mouse>();
        var mouseStatus = player.GetComponent<MouseTeleport>();

        if (mouse && mouseStatus && !mouseStatus.isTeleporting)
        {
            mouseStatus.isTeleporting = true;
            inUse = true;
            var exitStatus = exit.GetComponent<Portal>();
            player.transform.position = exit.transform.position;
            player.transform.rotation = exit.transform.rotation;
        }

    }
    void OnTriggerExit(Collider other)
    //void OnCollisionEnter(Collision other)
    {

        Debug.Log("Trigger Exit");

        GameObject player = other.gameObject;
        var mouse = player.GetComponent<Mouse>();
        var mouseStatus = player.GetComponent<MouseTeleport>();
        var exitStatus = exit.GetComponent<Portal>();

        if (mouse && mouseStatus && mouseStatus.isTeleporting && exitStatus && exitStatus.inUse)
        {
            mouseStatus.isTeleporting = false;
            exitStatus.inUse = false;
        }

    }


}
