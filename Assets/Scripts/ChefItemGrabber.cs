using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefItemGrabber : MonoBehaviour
{

    public Transform attachPoint;
    PlayerType playerType = PlayerType.Chef;

    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonHeld = false;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    

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
        }

        if (triggerButtonUp)
        {
            Debug.Log("Up");
        }

        if (triggerButtonUp && itemHeld)
        {
            //drop item
            itemHeld.Drop();

            FixedJoint joint = GetComponent<FixedJoint>();
            if (joint && joint.connectedBody)
            {
                Debug.Log("Joint Disconnected");
                joint.connectedBody = null;
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
            }
            
            itemHeld = item;
        }
    }

    void OnTriggerEntered(Collider other)
    //void OnCollisionEnter(Collision other)
    {
        Debug.Log("touch enter");


    }
}
