using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHealth : MonoBehaviour {

    public float smashThreshold = 2;

    Vector3 originalScale;

    // Use this for initialization
    void Start () {
        originalScale = transform.localScale;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Smash()
    {
        StartCoroutine(SmashDelay());
    }

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("mouse hit mag" + collision.relativeVelocity.magnitude);

        if (collision.relativeVelocity.magnitude > smashThreshold && collision.gameObject.CompareTag("Mallet"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("mouse smash");
            Smash();

        }
    }

    IEnumerator SmashDelay()
    {
        Vector3 oldPos = transform.position;
        transform.localScale = new Vector3(originalScale.x*1.2f, originalScale.y*.25f, originalScale.z*1.2f);
        transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z);
        yield return new WaitForSeconds(3);
        transform.localScale = originalScale;
        transform.position = oldPos;
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForEndOfFrame();
    }
}
