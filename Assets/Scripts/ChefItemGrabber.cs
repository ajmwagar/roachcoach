using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChefItemGrabber : MonoBehaviour
{

    public Transform attachPoint;
    PlayerType playerType = PlayerType.Chef;

    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonHeld = false;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

	private Animator anim;
    

    public ItemPickUp itemHeld;

    private SteamVR_Controller.Device controller
    {

        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);

        }

    }

    private SteamVR_TrackedObject trackedObj;

    void Start()
    {

        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }

    void Update()
    {

        if (controller == null)
        {

            Debug.Log("Controller not initialized");

            return;

        }

        triggerButtonHeld = controller.GetPress(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);
        triggerButtonDown = controller.GetPressDown(triggerButton);

        if (triggerButtonDown)
        {
            Debug.Log("down");
			SetAnimationState ("Grab", true);
        }

        if (triggerButtonUp)
        {
            Debug.Log("Up");
			SetAnimationState ("Grab", false);
        }

        if (triggerButtonUp && itemHeld)
        {
            //drop item
            itemHeld.Drop();

            FixedJoint joint = GetComponent<FixedJoint>();
            if (joint && joint.connectedBody)
            {
                //if dropping mouse enable controls
                var mouse = joint.connectedBody.GetComponentInChildren<Mouse>();

                Debug.Log("Joint Disconnected");
                joint.connectedBody = null;

                if (mouse)
                {
                    mouse.GetComponentInChildren<Basic3DRBmovement>().enabled = false;
                }


            }

            //no item held
            itemHeld = null;
        }

    }


    void OnTriggerStay(Collider other)
    //void OnCollisionEnter(Collision other)
    {
        Debug.Log("touch");

        ItemPickUp item = other.GetComponentInParent<ItemPickUp>();
        if (item && triggerButtonDown)
        {
            Debug.Log("grabbed");
            //item.HeldBy(attachPoint, playerType);

            FixedJoint joint = GetComponent<FixedJoint>();
            if (joint)
            {
                Debug.Log("JointConnected");
                joint.connectedBody = other.attachedRigidbody;

                //if picking up mouse disable mouse controls
                var mouse = other.GetComponentInChildren<Mouse>();
                if (mouse)
                {
                    mouse.GetComponentInChildren<Basic3DRBmovement>().enabled = false;
                }
            }
            
            itemHeld = item;
        }
    }

    void OnTriggerEntered(Collider other)
    //void OnCollisionEnter(Collision other)
    {
        Debug.Log("touch enter");
    }

	public void SetAnimator(Animator anim)
	{
        this.anim = anim;
	}

	private void SetAnimationState(string name, bool state)
	{
		if (anim == null)
		{
			Debug.LogWarning ("no animator set on : " + gameObject.name);
			return;
		}


		anim.SetBool (name, state);
	}
}
