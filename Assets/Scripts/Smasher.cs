using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour {

    public float smashThreshold = 2;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("hit mag" + collision.relativeVelocity.magnitude);

        if (collision.relativeVelocity.magnitude > smashThreshold)
        {
            Debug.Log("smash");

            GameObject hit = collision.collider.gameObject;

            var mouseHealth = hit.GetComponent<MouseHealth>();

            if (mouseHealth)
            {
                mouseHealth.Smash();
            }

        }
    }

    void OnTriggerEnter()
    {

        Debug.Log("trig");

    }

}
