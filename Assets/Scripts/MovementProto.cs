using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class MovementProto : MonoBehaviour 
{

	[SerializeField]
	private float moveSpeed = 150.0f;
	[SerializeField]
	private float rotationSpeed = 3.0f;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * rotationSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
		
	}
}
