using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class MovementProto : MonoBehaviour 
{

	[SerializeField]
	private float moveSpeed = 3.0f;
	[SerializeField]
	private float rotationSpeed = 150.0f;

    public Animator anim;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        Debug.Log(z*100);
        if (anim)
        {
            anim.SetFloat("Speed", z*100);
        }
		
	}
}
