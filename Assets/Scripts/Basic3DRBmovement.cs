using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Basic3DRBmovement : MonoBehaviour {

	//walclimb check
	public bool canClimb;

	Rigidbody rb;
	Animator anim;

	public float maxSpeed = 2;
	public float maxRotationalSpeed = 2;

	//for checking ground
	[SerializeField]
	bool grounded = false;
	float groundRadius = 1.1f;
	public LayerMask ground;

	//for jumping
	public float jumpForce= 10f;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;

	// Use this for initialization
	void Start () {
		rb = GetComponentInParent<Rigidbody> ();
		//idiot proofing the rigidbody constaints
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;


		anim = GetComponent<Animator> ();

		//groundCheck = this.gameObject.transform;
	}

	// Update is called once per frame
	void Update () {

		//check if jumping
		Jump ();
	}

	void FixedUpdate()
	{
		//move the character
		Movement ();

		//check for fall off edge
		Respawner();
	}

	void LateUpdate(){

		//Check for ground
		AreWeOnTheGround ();
	}

	void Movement()
	{
		//convert button input to speed
		float move = Input.GetAxis ("Vertical"); 
		move = (Mathf.Abs(move) < Mathf.Abs(Input.GetAxis ("Vertical")) ) ? Input.GetAxis ("Vertical") : move ;

		/*
		float straif = Input.GetAxis ("Straif");
		straif = (Mathf.Abs(straif) < Mathf.Abs(Input.GetAxis ("Straif")) ) ? Input.GetAxis ("Straif") : straif ;
		//normalized to ensure diagonal movement is not faster then forward or lateral movement.
		*/

		Vector3 movement = transform.forward * move;
		//Vector3 sidestep = transform.right * straif;
		movement = (movement /* + sidestep*/).normalized * maxSpeed;

		//convert button input to rotation
		float rot = Input.GetAxis ("Horizontal");
		rot = (Mathf.Abs(rot) < Mathf.Abs(Input.GetAxis ("Horizontal")) ) ? Input.GetAxis ("Horizontal") : rot ;

		// rotation
		rb.angularVelocity = new Vector3(0f, rot * maxRotationalSpeed, 0f);
		rb.velocity = new Vector3(movement.x,rb.velocity.y,movement.z);

		if (anim != null) {
			//tell animator the speed of movement
			anim.SetFloat ("Speed", Mathf.Abs (move));
		}

		if (canClimb) {
			Climb ();
		}
	}

	void Climb()
	{
		//convert button input to verticle speed
		float move = Input.GetAxis ("Vertical"); 
		move = (Mathf.Abs(move) < Mathf.Abs(Input.GetAxis ("Vertical")) ) ? Input.GetAxis ("Vertical") : move ;

		Vector3 movement = transform.up * move;
		//Vector3 sidestep = transform.right * straif;
		movement = (movement /* + sidestep*/).normalized * maxSpeed;

		rb.velocity = new Vector3(rb.velocity.x,movement.y,rb.velocity.z);
	}
	
	//Check for ground contact
	void AreWeOnTheGround() {
		grounded = Physics.CheckSphere (transform.position, groundRadius, ground);
		Debug.Log (ground);
		Debug.DrawRay (transform.position, Vector3.up * 5f);

		if (anim != null) {
			anim.SetBool("Ground",grounded);
			//send verticle speed to animator
			anim.SetFloat("vSpeed",rb.velocity.y);
		}
	}

	void Jump(){

		if (grounded && Input.GetButtonDown ("Jump")) {
			if (anim != null) {
				anim.SetBool ("Jump", true);
			}
			Launch ();
		} else {
			if (anim != null) {
				anim.SetBool ("Jump", false);
			}
		}
	}

	public void Launch(){
		rb.AddForce(new Vector2(0,jumpForce * rb.mass));
	}

	void Respawner()
	{
		if (transform.root.position.y < -20f) 
		{
			transform.root.position = Vector3.zero;
		}
	}
}